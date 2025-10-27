using UnityEngine;

public class GroundMovement : PlayerMovementBase
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float jumpForce = 6f;
    [SerializeField] private LayerMask groundMask;

    private bool isGrounded => Physics.Raycast(playerTransform.position, Vector3.down, 1.1f, groundMask);

    public override MovementState State => MovementState.Ground;

    public override void HandleMovement()
    {
        if (input == null)
        {
            Debug.LogError("❌ GroundMovement: input null! Initialize çağrılmamış veya PlayerInputHandler bulunamadı.");
            return;
        }

        Vector2 moveInput = input.MoveInput;
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {
            Vector3 targetDirection = Camera.main.transform.TransformDirection(moveDirection);
            targetDirection.y = 0;
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, Quaternion.LookRotation(targetDirection), rotationSpeed * Time.deltaTime);
            rb.MovePosition(rb.position + targetDirection * moveSpeed * Time.deltaTime);
        }

        if (input.IsJumping && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}

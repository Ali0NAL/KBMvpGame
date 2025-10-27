using UnityEngine;

public class AirMovement : PlayerMovementBase
{
    [SerializeField] private float airControl = 0.3f;

    public override MovementState State => MovementState.Air;

    public override void HandleMovement()
    {
        Vector2 moveInput = input.MoveInput;
        Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y);
        rb.AddForce(moveDir * airControl, ForceMode.Acceleration);
    }
}

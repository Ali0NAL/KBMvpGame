using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerInputHandler input;
    private PlayerMovementBase currentMovement;

    [SerializeField] private GroundMovement groundMovement;
    [SerializeField] private AirMovement airMovement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInputHandler>();
    }

    private void Start()
    {
        if (groundMovement == null || airMovement == null)
        {
            Debug.LogError("Movement script referansları eksik!");
            return;
        }

        groundMovement.Initialize(rb, input, transform);
        airMovement.Initialize(rb, input, transform);

        currentMovement = groundMovement;
        Debug.Log("✅ GroundMovement initialize edildi.");
    }

    private void Update()
    {
        if (currentMovement == null)
        {
            Debug.LogWarning("currentMovement null");
            return;
        }

        if (!IsGrounded() && currentMovement.State != MovementState.Air)
            SwitchMovement(airMovement);
        else if (IsGrounded() && currentMovement.State != MovementState.Ground)
            SwitchMovement(groundMovement);
    }

    private void FixedUpdate()
    {
        if (currentMovement == null)
        {
            Debug.LogWarning("currentMovement null");
            return;
        }

        currentMovement.HandleMovement();
    }

    private void SwitchMovement(PlayerMovementBase newMovement)
    {
        currentMovement = newMovement;
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}

using UnityEngine;

public abstract class PlayerMovementBase : MonoBehaviour
{
    protected Rigidbody rb;
    protected PlayerInputHandler input;
    protected Transform playerTransform;

    public abstract MovementState State { get; }

    public virtual void Initialize(Rigidbody rigidbody, PlayerInputHandler inputHandler, Transform transform)
    {
        rb = rigidbody;
        input = inputHandler;
        playerTransform = transform;
    }

    public abstract void HandleMovement();
}

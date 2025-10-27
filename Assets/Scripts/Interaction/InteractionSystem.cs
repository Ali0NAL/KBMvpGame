using UnityEngine;

[RequireComponent(typeof(InteractionInput))]
public class InteractionSystem : MonoBehaviour
{
    [SerializeField] private InteractionMethod interactionMethod;

    private InteractionInput input;
    private IInteractable currentInteractable;

    private void Awake()
    {
        input = GetComponent<InteractionInput>();
    }

    private void Update()
    {
        IInteractable detected = interactionMethod.DetectInteractable();

        if (detected != currentInteractable)
        {
            if (currentInteractable != null)
            {
                currentInteractable.OnFocusExit();
            }

            currentInteractable = detected;

            if (currentInteractable != null)
            {
                if (currentInteractable is BaseInteractable baseInt)
                    baseInt.SetPlayer(transform);

                currentInteractable.OnFocusEnter();
            }
        }

        // input test
        bool pressed = input.IsInteracting();

        if (currentInteractable != null)
        {
            if (pressed)
            {
                currentInteractable.Interact(gameObject);
            }
        }
    }
}

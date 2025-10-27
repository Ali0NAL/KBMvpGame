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
        currentInteractable = interactionMethod.DetectInteractable();

        if (currentInteractable != null)
        {
            // prompt gosterebiliriz
            // TODOO: UI sistemi eklendiginde buraya ekle
            if (input.IsInteracting())
            {
                currentInteractable.Interact(gameObject);
            }
        }
    }
}

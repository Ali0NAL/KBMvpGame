using UnityEngine;

public class RaycastInteraction : InteractionMethod
{
    [SerializeField] private float interactRange = 3f;
    [SerializeField] private LayerMask interactLayer;
    [SerializeField] private Camera cam;

    public override IInteractable DetectInteractable()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, interactRange, interactLayer))
        {
            return hit.collider.GetComponent<IInteractable>();
        }
        return null;
    }
}

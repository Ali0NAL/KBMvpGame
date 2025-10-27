using UnityEngine;

public class RaycastInteraction : InteractionMethod
{
    [Header("Interaction")]
    [SerializeField] private float interactRange = 3f;
    [SerializeField] private LayerMask interactLayer;
    [SerializeField] private Camera cam;
    [SerializeField] private bool usePlayerOrigin = false;
    [SerializeField] private Transform playerOrigin;
    [Header("Gizmos")]
    [SerializeField] private bool drawGizmos = true;
    [SerializeField] private Color rayColor = new Color(0f, 1f, 1f, 0.6f);
    [SerializeField] private Color hitColor = new Color(0f, 1f, 0f, 0.6f);
    [SerializeField] private Color missColor = new Color(1f, 0f, 0f, 0.4f);
    [SerializeField] private float hitSphereRadius = 0.15f;

    public override IInteractable DetectInteractable()
    {
        Vector3 origin;
        Vector3 direction;

        if (usePlayerOrigin && playerOrigin != null)
        {
            origin = playerOrigin.position + Vector3.up * 1.5f; 
            direction = playerOrigin.forward;
        }
        else
        {
            Camera c = cam != null ? cam : Camera.main;
            if (c == null) return null;
            origin = c.transform.position;
            direction = c.transform.forward;
        }

        if (Physics.Raycast(origin, direction, out RaycastHit hit, interactRange, interactLayer))
        {
            return hit.collider.GetComponent<IInteractable>();
        }
        
        return null;
    }

    private void OnDrawGizmos()
    {
        if (!drawGizmos) return;

        Vector3 origin;
        Vector3 direction;

        if (usePlayerOrigin && playerOrigin != null)
        {
            origin = playerOrigin.position + Vector3.up * 1.5f;
            direction = playerOrigin.forward;
        }
        else
        {
            Camera c = cam != null ? cam : Camera.main;
            if (c == null) return;
            origin = c.transform.position;
            direction = c.transform.forward;
        }

        Gizmos.color = rayColor;
        Gizmos.DrawRay(origin, direction * interactRange);

        if (Physics.Raycast(origin, direction, out RaycastHit hit, interactRange, interactLayer))
        {
            Gizmos.color = hitColor;
            Gizmos.DrawWireSphere(hit.point, hitSphereRadius);

#if UNITY_EDITOR
            var interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                UnityEditor.Handles.color = Color.white;
                UnityEditor.Handles.Label(
                    hit.point + Vector3.up * (hitSphereRadius + 0.05f),
                    $"[{hit.collider.name}]  •  {interactable.InteractionPrompt}"
                );
            }
#endif
        }
        else
        {
            Gizmos.color = missColor;
            Gizmos.DrawWireSphere(origin + direction * interactRange, 0.08f);
        }
    }
}

using UnityEngine;
using TMPro;

[RequireComponent(typeof(Collider))]
public abstract class BaseInteractable : MonoBehaviour, IInteractable
{
    [Header("Base Interaction Settings")]
    [SerializeField] protected string interactionPrompt = "Interact";
    [SerializeField] protected float interactDistance = 3f;

    [Header("Prompt UI (World Space Canvas)")]
    [SerializeField] protected Canvas promptCanvas;
    [SerializeField] protected TextMeshProUGUI promptText;

    protected Transform player;
    protected bool isPlayerNearby;

    // Interface implementasyonu
    public virtual string InteractionPrompt => interactionPrompt;

    protected virtual void Start()
    {
        if (promptCanvas != null)
            promptCanvas.gameObject.SetActive(false);
    }

    protected virtual void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(player.position, transform.position);
        bool shouldShow = distance <= interactDistance;

        if (shouldShow && !isPlayerNearby)
        {
            isPlayerNearby = true;
            OnFocusEnter();
        }
        else if (!shouldShow && isPlayerNearby)
        {
            isPlayerNearby = false;
            OnFocusExit();
        }
    }

    public virtual void SetPlayer(Transform playerTransform)
    {
        player = playerTransform;
    }

    public abstract void Interact(GameObject interactor);

    public virtual void OnFocusEnter()
    {
        if (promptCanvas != null && promptText != null)
        {
            promptText.text = InteractionPrompt; // 🎯 prompt’ı yaz
            promptCanvas.gameObject.SetActive(true);
        }
    }

    public virtual void OnFocusExit()
    {
        if (promptCanvas != null)
            promptCanvas.gameObject.SetActive(false);
    }
}

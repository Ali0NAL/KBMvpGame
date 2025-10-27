using UnityEngine;

public abstract class Interactable : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactionPrompt = "Interact";

    public string InteractionPrompt => interactionPrompt;

    public abstract void Interact(GameObject interactor);

    public void OnFocusEnter()
    {
        throw new System.NotImplementedException();
    }

    public void OnFocusExit()
    {
        throw new System.NotImplementedException();
    }
}

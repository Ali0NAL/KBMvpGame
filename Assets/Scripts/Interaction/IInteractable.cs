using UnityEngine;

public interface IInteractable
{
    string InteractionPrompt { get; }
    void Interact(GameObject interactor);
    void OnFocusEnter();
    void OnFocusExit();
}

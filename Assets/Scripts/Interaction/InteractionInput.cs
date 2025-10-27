using UnityEngine;

public class InteractionInput : MonoBehaviour
{
    private bool uiInteractPressed = false;

    public bool IsInteracting()
    {
        bool keyboardInput = Input.GetKeyDown(KeyCode.E);
        bool uiInput = uiInteractPressed;

        if (uiInteractPressed)
            uiInteractPressed = false; 

        return keyboardInput || uiInput;
    }

    public void OnUIInteractPressed()
    {
        uiInteractPressed = true;
    }
}

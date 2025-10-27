using UnityEngine;

public class ColorChangeInteractable : BaseInteractable
{
    private Renderer rend;
    private Color originalColor;
    private Color targetColor;
    private bool isChanged = false;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material = new Material(rend.material);

            originalColor = rend.material.color;
            targetColor = new Color(Random.value, Random.value, Random.value);
        }
    }

    public override void Interact(GameObject interactor)
    {

        if (isChanged)
        {
            rend.material.color = originalColor;
            isChanged = false;
        }
        else
        {
            rend.material.color = targetColor;
            isChanged = true;
        }
    }
}

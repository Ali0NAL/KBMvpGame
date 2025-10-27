using UnityEngine;

public class InteractionInput : MonoBehaviour
{
    public bool IsInteracting()
    {
        return Input.GetKeyDown(KeyCode.E); // Yeni Input sisteme kolayca uyarlanabilir
    }
}

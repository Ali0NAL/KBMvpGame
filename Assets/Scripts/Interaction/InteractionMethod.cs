using UnityEngine;

public abstract class InteractionMethod : MonoBehaviour
{
    public abstract IInteractable DetectInteractable();

    //Burda birbirinden farklı methodlar oluşturabiliriz şimdilik raycast var :=)
}

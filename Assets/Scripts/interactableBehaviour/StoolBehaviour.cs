using Inventory;
using UnityEngine;

public class StoolBehaviour : interactableBehaviour
{
    public override void Interact()
    {
        Debug.Log("Stool interact");
        Animator.SetTrigger("Interact");

    }
    public void AnimationEnd()
    {
        Info.Done = true;
        InventoryManager.instance.AddItem(Info.Name);
        gameObject.SetActive(false);
    }
}
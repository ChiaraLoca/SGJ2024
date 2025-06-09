using Inventory;
using UnityEngine;
public class RemoteBehaviour : interactableBehaviour
{
    public override void Interact()
    {
        Debug.Log("Remote interact");
        Animator.SetTrigger("Interact");
        
    }
    public void AnimationEnd()
    { 
        Info.Done= true;
        InventoryManager.instance.AddItem(Info.Name);
        Destroy(gameObject);
    }
}

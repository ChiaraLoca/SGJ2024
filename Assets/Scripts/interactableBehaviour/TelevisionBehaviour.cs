using GameStatus;
using Inventory;
using UnityEngine;

public class TelevisionBehaviour : interactableBehaviour
{
    public override void Interact()
    {
        if (InventoryManager.instance.IsPresent("Remote"))
        {
            GameStatusManager.instance.PlayerBehaviour.DisableMoving();
            Animator.SetTrigger("Interact");
            AudioSource.loop = false;
            AudioSource.Play();
            Info.Done=true;
        }
       
    }

    public void AnimationEvent()
    {
        GameStatusManager.instance.PlayerBehaviour.Animator.SetTrigger("TV");

    }
}

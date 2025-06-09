using GameStatus;
using Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VasoBehaviour : interactableBehaviour
{

    public override void Interact()
    {   
        if (InventoryManager.instance.IsPresent("Lighter"))
        {
            GameStatusManager.instance.PlayerBehaviour.DisableMoving();
            Animator.SetTrigger("Interact");
            Info.Done = true;

            AudioSource.loop = false;
            AudioSource.Play();
            GameStatusManager.instance.PlayerBehaviour.BlockPlayer(1f);
           
        }
    }

    private IEnumerator KillPlayerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Kill Vaso");
        GameStatusManager.instance.KillPlayer();
    }

    public void Kill()
    {
        GameStatusManager.instance.KillPlayer();
    }

}

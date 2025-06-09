using GameStatus;
using Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FridgeBehaviour : interactableBehaviour
{
    [SerializeField] private GameObject _stool;

    public override void Interact()
    {
        if (InventoryManager.instance.IsPresent("Stool"))
        {
            GameStatusManager.instance.PlayerBehaviour.DisableMoving();
            GameStatus.GameStatusManager.instance.PlayerBehaviour.Animator.SetTrigger("fridge");
            Animator.SetTrigger("interact");
            AudioSource.loop = false;
            AudioSource.PlayDelayed(1f);
            _stool.gameObject.SetActive(true);
        }
    }



    public void EndAnimation()
    {
        Info.Done = true;
        Debug.Log("Kill Fridge");
        GameStatus.GameStatusManager.instance.KillPlayer();
        BoxCollider2D.enabled = false;
        
    }
}

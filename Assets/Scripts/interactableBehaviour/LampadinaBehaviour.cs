using GameStatus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampadinaBehaviour : interactableBehaviour
{
    [SerializeField] Collider2D WCCollider;

    public override void Interact()
    {
        GameStatusManager.instance.PlayerBehaviour.DisableMoving();
        Animator.SetTrigger("lampadina");
        Info.Done = true;
    }



    public void StartAnimation()
    {
        GameStatus.GameStatusManager.instance.PlayerBehaviour.transform.position = new Vector3(GameStatus.GameStatusManager.instance.PlayerBehaviour.transform.position.x, GameStatus.GameStatusManager.instance.PlayerBehaviour.transform.position.y + 2, GameStatus.GameStatusManager.instance.PlayerBehaviour.transform.position.z);
        WCCollider.enabled = true;
        GameStatus.GameStatusManager.instance.PlayerBehaviour.Animator.SetTrigger("WC");

    }

    public void Electrocute()
    {

    }

    public void EndAnimation()
    {
        WCCollider.enabled = false;
    }
}

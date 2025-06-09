using GameStatus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaScript : interactableBehaviour
{
    private int Status = 0;
    // Start is called before the first frame update

    public override void Interact()
    {
        if (Status == 0)
        {
            Animator.SetTrigger("Interact");
            Status++;
        }
        else
        {
            GameStatusManager.instance.PlayerBehaviour.DisableMoving();
            Animator.SetTrigger("Trigger");
            AudioSource.loop = false;
            AudioSource.Play();
            Info.Done = true;
            GameStatusManager.instance.KillPlayer();
        }


    }

    private IEnumerator KillAfterDelay(float v)
    {
        GameStatusManager.instance.PlayerBehaviour.GetComponentInChildren<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(v);
        
        GameStatusManager.instance.PlayerBehaviour.GetComponentInChildren<SpriteRenderer>().enabled = true;

    }
}

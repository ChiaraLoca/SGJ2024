using GameStatus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocciaBehaviour : interactableBehaviour
{
    private int Status = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        if(Status == 0)
        {
            Animator.SetTrigger("Interact");
            Status++;

        }
        else
        {
            Animator.SetTrigger("Trigger");
            Info.Done = true;
            GameStatusManager.instance.PlayerBehaviour.DisableMoving();
            GameStatusManager.instance.PlayerBehaviour.GetComponentInChildren<SpriteRenderer>().enabled = false;
            // StartCoroutine(KillAfterDelay(1f));
        }

  
    }

    public void Kill() {
        GameStatusManager.instance.KillPlayer();
    }

    private IEnumerator KillAfterDelay(float v)
    {
       
        yield return new WaitForSeconds(v);
       
        GameStatusManager.instance.PlayerBehaviour.GetComponentInChildren<SpriteRenderer>().enabled = true;
        
    }
}

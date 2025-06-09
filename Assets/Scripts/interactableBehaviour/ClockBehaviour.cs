using GameStatus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockBehaviour : interactableBehaviour
{
    [SerializeField] GameObject Letto;
    [SerializeField] GameObject Ossa;
    int PlayerAge = 0;
    int Days = 0;
    public override void Interact()
    {
        Animator.SetTrigger("Interact");
        
        Letto.GetComponent<BedBehaviour>().CanFreddy = false;
        Letto.GetComponent<BedBehaviour>().ResetFreddy();
        Days++;
        if(Days == 4)
        {
           // Debug.Log("Here1");
            GameStatusManager.instance.PlayerBehaviour.ChangeAge(2);
        }
        if(Days == 8)
        {
            GameStatusManager.instance.PlayerBehaviour.ChangeAge(1);
            Info.Done = true;
            Animator.SetTrigger("Broke");
            Ossa.GetComponent<SpriteRenderer>().enabled = true;
            GameStatusManager.instance.KillPlayer();
        }

    }

  





}

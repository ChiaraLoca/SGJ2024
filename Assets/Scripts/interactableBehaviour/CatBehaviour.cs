using GameStatus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class CatBehaviour : interactableBehaviour
{
    EdgeCollider2D _collider;
    [SerializeField] int catFat = 2;
    [SerializeField] GameObject Sprite0;
    [SerializeField] GameObject Sprite1;
    [SerializeField] GameObject Sprite2;
    [SerializeField] GameObject Blood;
    [SerializeField] AudioClip mao1;
    [SerializeField] AudioClip mao2;
    [SerializeField] AudioClip mao3;
    SpriteRenderer _spriteRenderer;
    private bool canKill = false;
    
   
    public override void Interact()
    {
      
    }

    protected override void CustomStart()
    {
        _collider = GetComponentInChildren<EdgeCollider2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Sprite0.GetComponent<SpriteRenderer>().enabled = true;
        AudioSource.clip = mao1;
        AudioSource.loop = true;
        AudioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.GetComponent<playerBehaviour>() != null && catFat == 2 )
        {
            HitPlayer(collision);
            
        }

        if (collision.gameObject.GetComponent<BowlBehaviour>() != null)
        {
            //Debug.Log("pippo");
            HitBowl(collision);
        }


    }

    private void HitBowl(Collider2D collision)
    {
        BowlBehaviour b = collision.gameObject.GetComponent<BowlBehaviour>();
        //Debug.Log("Cat HIT");
        if (b.IsFull && catFat<2)
        {
            b.IsFull = false;
            catFat += 1;
            if(catFat == 1)
            {
                AudioSource.clip = mao2;
            }
            if (catFat == 2)
            {
                AudioSource.clip = mao3;
            }
            AudioSource.loop = true;
            AudioSource.Play();
            GetComponent<Animator>().SetTrigger("Eating");
            switch (catFat)
            {
                case 1:
                    Sprite0.GetComponent<SpriteRenderer>().enabled = true;
                    Sprite1.GetComponent<SpriteRenderer>().enabled = true;
                    break;
                case 2:
                    Sprite1.GetComponent<SpriteRenderer>().enabled = true;
                    Sprite2.GetComponent<SpriteRenderer>().enabled = true;
                    canKill = true;
                    break;
            }
        }
    }

    private void HitPlayer(Collider2D collision)
    {
        if (canKill )
        {
            GameStatusManager.instance.PlayerBehaviour.DisableMoving();
            canKill = false;
            GameStatusManager.instance.PlayerBehaviour.AudioSource.loop = false;
            GameStatusManager.instance.PlayerBehaviour.AudioSource.Play();
            Vector3 catPosition;
            Quaternion rotation;
            GetComponent<Transform>().GetPositionAndRotation(out catPosition,out rotation);
            catPosition.y += 3;
            Blood.GetComponent<Transform>().SetPositionAndRotation(catPosition, new Quaternion());
            Blood.GetComponent<SpriteRenderer>().enabled = true;
            GameStatusManager.instance.KillPlayer();
        }

    }

    private IEnumerator KillPlayerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Kill Cat");
        GameStatusManager.instance.KillPlayer();
    }
}

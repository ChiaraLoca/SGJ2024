using GameStatus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BedBehaviour : interactableBehaviour
{
    [SerializeField] FreddyBehaviour _freddyBehaviour;
    public bool CanFreddy = true;
    public bool FreddyDone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Interact()
    {
        CanFreddy = true;
        Transform trans = GameStatusManager.instance.PlayerBehaviour.GetComponentInChildren<Transform>();
        trans.SetPositionAndRotation(new Vector3(trans.position.x-2, trans.position.y + 2), new Quaternion());
        StartCoroutine(CheckFreddy());


    }

    private IEnumerator CheckFreddy()
    {
        yield return new WaitForSeconds(5);
       // Debug.Log(CanFreddy);
        Transform trans = GameStatusManager.instance.PlayerBehaviour.GetComponentInChildren<Transform>();
        Debug.Log("CheckFreddy " + trans.position.y + 1);
        if (trans.position.y + 1 >= 2 && CanFreddy)
        {
            
            Animator.SetTrigger("interact");
            AudioSource.loop = false;
            AudioSource.Play();
            GameStatusManager.instance.PlayerBehaviour.GetComponentInChildren<SpriteRenderer>().enabled = false;
            FreddyDone = true;
            _freddyBehaviour.Info.Done = true;

           
          
        }
    }
    public IEnumerator ResetFreddy()
    {
        yield return new WaitForSeconds(5);
        CanFreddy = true;
    }
    
    public void Kill()
    {
        GameStatusManager.instance.KillPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

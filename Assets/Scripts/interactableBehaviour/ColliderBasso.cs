using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBasso : interactableBehaviour
{
    public override void Interact()
    {
        Animator.SetTrigger("ladderBasso");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndAnimation()
    {
        GameStatus.GameStatusManager.instance.PlayerBehaviour.gameObject.SetActive(true);
    }

    public void StartAnimation()
    {
        AudioSource.loop = false;
        AudioSource.Play();
        GameStatus.GameStatusManager.instance.PlayerBehaviour.gameObject.SetActive(false);
        GameStatus.GameStatusManager.instance.PlayerBehaviour.transform.position = new Vector3(GameStatus.GameStatusManager.instance.PlayerBehaviour.transform.position.x, GameStatus.GameStatusManager.instance.PlayerBehaviour.transform.position.y + 5, GameStatus.GameStatusManager.instance.PlayerBehaviour.transform.position.z);
    }
}

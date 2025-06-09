using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlBehaviour : interactableBehaviour
{
    public bool IsFull = false;
    [SerializeField] GameObject Pappa;
    private int FoodCount = 0;
    SpriteRenderer _pappaRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _pappaRenderer = Pappa.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFull)
        {
            _pappaRenderer.gameObject.SetActive(true);
        }
        else _pappaRenderer.gameObject.SetActive(false);
    }

    public override void Interact()
    {
        Animator.SetTrigger("Interact");
       // Info.Done = true;
        IsFull = true;
        AudioSource.loop = false;
        AudioSource.Play();
    }




}

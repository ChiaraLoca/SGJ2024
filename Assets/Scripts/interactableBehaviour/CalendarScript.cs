using GameStatus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarScript : interactableBehaviour
{
    private int CurrentDay = 0;
    [SerializeField] GameObject Day1;
    [SerializeField] GameObject Day2;
    [SerializeField] GameObject Day3;
    [SerializeField] GameObject Day4;
    [SerializeField] GameObject Day5;
    [SerializeField] GameObject Day6;
    [SerializeField] GameObject Day7;
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
        if (GameStatusManager.instance.IsInteractionDone("Phone"))
        {
            CurrentDay++;
            switch (CurrentDay)
            {
                case 1:
                    Day1.GetComponent<SpriteRenderer>().enabled = false;
                    Day2.GetComponent<SpriteRenderer>().enabled = true;
                    break;
                case 2:
                    Day2.GetComponent<SpriteRenderer>().enabled = false;
                    Day3.GetComponent<SpriteRenderer>().enabled = true;
                    break;
                case 3:
                    Day3.GetComponent<SpriteRenderer>().enabled = false;
                    Day4.GetComponent<SpriteRenderer>().enabled = true;
                    break;
                case 4:
                    Day4.GetComponent<SpriteRenderer>().enabled = false;
                    Day5.GetComponent<SpriteRenderer>().enabled = true;
                    break;
                case 5:
                    Day5.GetComponent<SpriteRenderer>().enabled = false;
                    Day6.GetComponent<SpriteRenderer>().enabled = true;
                    break;
                case 6:
                    Day6.GetComponent<SpriteRenderer>().enabled = false;
                    Day7.GetComponent<SpriteRenderer>().enabled = true;
                    break;
                case 7:
                    Day7.GetComponent<SpriteRenderer>().enabled = false;
                    GameStatusManager.instance.PlayerBehaviour.Animator.SetTrigger("TV");
                    // StartCoroutine(KillAfterDelay(2));
                    break;

            }
        }


        
    }

}

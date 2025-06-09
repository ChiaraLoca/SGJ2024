using GameStatus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(AudioSource))]
public abstract class interactableBehaviour : MonoBehaviour
{

    [SerializeField] private InteractableInfo info;
    [Space]
    [SerializeField] public bool test = false;
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private AudioSource audioSource;

    public Animator Animator { get => animator; }
    public InteractableInfo Info { get => info; set => info = value; }
    public BoxCollider2D BoxCollider2D { get => boxCollider2D;  }
    public AudioSource AudioSource { get => audioSource; set => audioSource = value; }

    public abstract void Interact();

    private void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.isTrigger = true;
        CustomStart();
    }

    private void Update()
    {
        if (test)
        {
            test = false;
            Interact();
        }
        CustomUpdate();
    }
    protected virtual void CustomUpdate()
    {
        
    }

    protected virtual void CustomStart()
    {
        
    }


}
    
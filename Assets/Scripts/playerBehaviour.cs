using GameStatus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerBehaviour : MonoBehaviour
{
    [SerializeField] public float maxSpeed = 7f;
    [SerializeField] float acceleration = 3f;
    [SerializeField] GameObject _age1;
    [SerializeField] GameObject _age2;
    [SerializeField] private List<interactableBehaviour> interactables = new List<interactableBehaviour>();
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<SpriteRenderer> _sprites = new List<SpriteRenderer>();
    private bool CanMove = true;
    private Rigidbody2D _rigidbody;
    [SerializeField]  private Animator _animator;

    public Animator Animator { get => _animator; set => _animator = value; }
    public AudioSource AudioSource { get => audioSource; set => audioSource = value; }

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   /*if (!CanMove)
            return;
        if (Input.GetKey(KeyCode.LeftArrow) && _rigidbody.velocity.magnitude < maxSpeed)
        {
            _rigidbody.AddForce(new Vector2(-acceleration, 0));
            Debug.Log("tasto left");
        }
        if (Input.GetKey(KeyCode.RightArrow) && _rigidbody.velocity.magnitude < maxSpeed)
        {
            _rigidbody.AddForce(new Vector2(acceleration, 0));
           Debug.Log("tasto rigth");
        }
        if (Input.GetKeyDown(KeyCode.E) && CanInteract())
        {
            getClosestInteractable().Interact();
            ScoreManager.miss++;
        }
        if (_rigidbody.velocity.magnitude > 0.1)
        {
            Animator.SetBool("moving", true);
        } else
        {
            Animator.SetBool("moving", false);
        }*/

        if (!CanMove)
            return;

        float moveInput = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveInput = -1f;
            Debug.Log("tasto left");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveInput = 1f;
            Debug.Log("tasto right");
        }

        // Calculate desired horizontal velocity
        float targetVelocityX = moveInput * maxSpeed;

        // Clamp final velocity
        float clampedVelocityX = Mathf.Clamp(targetVelocityX, -maxSpeed, maxSpeed);
        Vector2 newVelocity = new Vector2(clampedVelocityX, _rigidbody.velocity.y);

        _rigidbody.velocity = newVelocity;

        // Interact logic
        if (Input.GetKeyDown(KeyCode.E) && CanInteract())
        {
            getClosestInteractable().Interact();
            ScoreManager.miss++;
        }

        // Animation
        if (Mathf.Abs(_rigidbody.velocity.x) > 0.1f)
        {
            Animator.SetBool("moving", true);
        }
        else
        {
            Animator.SetBool("moving", false);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactableBehaviour interactable = collision.gameObject.GetComponent<interactableBehaviour>();
        if (interactable != null)
        {
            interactables.Add(interactable);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactableBehaviour interactable = collision.gameObject.GetComponent<interactableBehaviour>();
        if (interactable != null && interactables.Contains(interactable))
        {
            interactables.Remove(interactable);
        }
    }

    private bool CanInteract()
    {
        if (interactables.Count > 0)
        {
            if (!getClosestInteractable().Info.Done)
            {
                return true;
            }
        }
        return false;
    }



    private interactableBehaviour getClosestInteractable()
    {
        interactableBehaviour closest = interactables[0];
        float closestDistance = Vector3.Distance(transform.position, closest.transform.position);
        foreach(interactableBehaviour interactable in interactables) {
            if(Vector3.Distance(transform.position, interactable.transform.position) < closestDistance)
            {
                closest = interactable;
                closestDistance = Vector3.Distance(transform.position, interactable.transform.position);
            }
        }
        return closest;
    }

    public IEnumerator BlockPlayer(float delay)
    {
        CanMove = false;
        yield return new WaitForSeconds(delay);
        CanMove = true;
    }

    public void EndTVAnimation()
    {
        Debug.Log("Kill TV");
        GameStatusManager.instance.KillPlayer();
    }

    public void ChangeAge(int age)
    {
        if(age == 1)
        {
            _age1.GetComponent<SpriteRenderer>().enabled = (true);
            _age2.GetComponent<SpriteRenderer>().enabled = (false);
        }
        if (age == 2)
        {
            _age1.GetComponent<SpriteRenderer>().enabled = (false);
            _age2.GetComponent<SpriteRenderer>().enabled = (true);
        }
    }

    public void Electrocute()
    {
        GameStatus.GameStatusManager.instance.KillPlayer();
    }

    public void EnableMoving()
    {
        CanMove = true;
    }
    public void DisableMoving()
    {
        CanMove = false;
        _rigidbody.velocity = Vector3.zero;
    }

    internal void DisableRenderer()
    {
        foreach (SpriteRenderer sprite in _sprites)
        {
            sprite.enabled = false;
        }
    }
}

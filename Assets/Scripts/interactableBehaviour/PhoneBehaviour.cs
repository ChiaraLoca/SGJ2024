using System.Collections;
using UnityEngine;

public class PhoneBehaviour : interactableBehaviour
{
    [SerializeField] float min = 30;
    [SerializeField] float max = 90;
    [SerializeField] float duration = 10;
    [SerializeField] private AudioClip ringSound;
    [SerializeField] private AudioClip answerSound;
    
    public override void Interact()
    {
        Debug.Log("Remote interact");
        Animator.SetTrigger("Interact");
        AudioSource.clip = answerSound;
        AudioSource.loop = false;
        AudioSource.Play();

        Info.Done = true;

    }

    public void PhoneRingingStart()
    {
        Animator.SetBool("Ring",true);
        BoxCollider2D.enabled = true;
        AudioSource.clip = ringSound;
        AudioSource.Play();
    }
    public void PhoneRingingEnd()
    {
        Animator.SetBool("Ring", false);
        BoxCollider2D.enabled = false;
        AudioSource.Stop();
    }

    private void Start()
    {
        StartCoroutine(WaitAndRing());
    }
    private IEnumerator WaitAndRing()
    {
        float time = Random.Range(min, max);
        yield return new WaitForSeconds(time);
        PhoneRingingStart();
        yield return new WaitForSeconds(duration);
        PhoneRingingEnd();

    }
}

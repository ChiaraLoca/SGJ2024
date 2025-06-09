using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGBehaviour : MonoBehaviour
{
    [SerializeField] GameObject Occhi;
    private bool CountOcchi = true;
    private Vector3 OriginalTransform;
    // Start is called before the first frame update
    void Start()
    {
        OriginalTransform = GetComponent<Transform>().position;
        StartCoroutine(LanciaOcchiAndWait());
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private IEnumerator LanciaOcchiAndWait()
    {
        float blinkInterval = Random.Range(5, 15);
        yield return new WaitForSeconds(blinkInterval);
        float y = Random.Range(-3, 3);
        float x = Random.Range(-7, 7);
        Debug.Log("pippo");
        Occhi.transform.position = new Vector3(OriginalTransform.x + x, OriginalTransform.y + y, OriginalTransform.z);
        GetComponent<Animator>().SetTrigger("Occhi");
        StartCoroutine(LanciaOcchiAndWait());

    }
}

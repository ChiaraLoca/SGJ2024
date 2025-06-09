using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBehaviour : MonoBehaviour
{
    [SerializeField] Image  DarkingPanel;
    [SerializeField] short TimeDivider;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fadeIn());
        AudioManager.instance.track(1, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator fadeIn()
    {
        
        for (float t = 0; t < 5; t += Time.deltaTime)
        {
            DarkingPanel.color = new Color(0, 0, 0, 1 - t/ TimeDivider);
            yield return null;

        }


    }
}

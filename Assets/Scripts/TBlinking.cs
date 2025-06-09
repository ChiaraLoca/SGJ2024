using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TBlinking : MonoBehaviour
{

    // Reference to the Text component
    private TextMeshProUGUI textComponent;

    // Minimum and maximum interval for blinking (in seconds)
    public float minBlinkInterval = 0.2f;
    public float maxBlinkInterval = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        // Get the Text component attached to the same GameObject
        textComponent = GetComponent<TextMeshProUGUI>();

        // Start the blinking coroutine
        StartCoroutine(BlinkText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BlinkText()
    {
         while (true)
        {
            // Wait for a random interval
            float blinkInterval = Random.Range(minBlinkInterval, maxBlinkInterval);
            yield return new WaitForSeconds(blinkInterval/2);

            // Toggle the visibility of the text component
            textComponent.enabled = !textComponent.enabled;
        }
    }

}

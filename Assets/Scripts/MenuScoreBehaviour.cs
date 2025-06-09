using GameStatus;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuScoreBehaviour : MonoBehaviour
{
    private TextMeshProUGUI textComponent;
    
    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //textComponent.text = GameStatusManager.instance.GetScore().ToString();
    }
}

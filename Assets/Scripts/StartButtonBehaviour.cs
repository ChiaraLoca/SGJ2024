using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Windows.Speech;

public class StartButtonBehaviour : MonoBehaviour
{
    [SerializeField] private Button _button;

 
    // Start is called before the first frame update
    void Start()
    {
        _button.onClick.AddListener(OnStartButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnStartButtonClicked()
    {
        Debug.Log("Start button clicked!");
        
        SceneManager.LoadScene("1_MainScene_Demo");
         
    }
}

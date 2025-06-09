using GameStatus;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    public static EndMenu instance;
    private void Awake()
    {
        instance = this;
    }
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Button _button;

    private void Start()
    {
        AudioManager.instance.track(3, false);

        _button.onClick.AddListener(() => {
            SceneManager.LoadScene("0_Menu_Demo");

        });

        //_text.text = "Punti" + ScoreManager.score + "\nErrori " + ScoreManager.death + "\nFallimento" + ScoreManager.miss;
        _text.text =$"Punti: {ScoreManager.score}";
    }
}

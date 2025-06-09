using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameStatus
{
    public class ScoreManager
    {
        public static int score;
        public static int death;
        public static int miss;

        internal static void Initialize()
        {
            score = 0; death=0; miss = 0;
        }
    }

    public class GameStatusManager : MonoBehaviour
    {
        public static GameStatusManager instance;
        [Header("Player")]
        [SerializeField] private playerBehaviour _playerBehaviourPrefab;
        private playerBehaviour _playerBehaviour;
        [SerializeField] private Transform _playerParent;
        [SerializeField] private Transform _playerSpawn;


        [Header("Interactable")]
        [SerializeField] private List<interactableBehaviour> _interactableehaviours = new List<interactableBehaviour>();
        [SerializeField] private Transform _interactableParent;

        [SerializeField] private float _maxSeconds;
        [SerializeField] private float _currentSeconds;
        private bool _gameRunning= false;

        public playerBehaviour PlayerBehaviour { get => _playerBehaviour; }

        private void Awake()
        {
            instance = this;
            
        }




        private void Update()
        {
            if (_gameRunning)
            {
                _currentSeconds += Time.deltaTime;
                TimerUI.instance.UpdateUI(_maxSeconds-_currentSeconds);
                if (_currentSeconds >= _maxSeconds)
                {
                    EndGame();
                }

            }


        }

        public void Start()
        {
            StartGame();
            //DontDestroyOnLoad(this);
        }

        public void Initialize()
        {
           
            ScoreManager.Initialize();
            foreach (interactableBehaviour interactableBehaviour in _interactableehaviours)
            {
                interactableBehaviour.Info.Done = false;
            }

            CreatePlayer();
        }

        

        public void CreatePlayer()
        {
            _playerBehaviour = Instantiate(_playerBehaviourPrefab, _playerParent);
            _playerBehaviour.transform.position = _playerSpawn.transform.position;
            _playerBehaviour.transform.rotation = _playerSpawn.transform.rotation;
            _playerBehaviour.transform.localScale = _playerSpawn.transform.localScale;
            _playerBehaviour.EnableMoving();
            _playerBehaviour.GetComponent<Rigidbody2D>().freezeRotation = true;
            _playerSpawn.gameObject.SetActive(false);
            _playerBehaviour.Animator.SetTrigger("Start");
        }
        public void KillPlayer()
        {
           // PlayerBehaviour.AudioSource.loop = false;
            //PlayerBehaviour.AudioSource.Play();
            PlayerBehaviour.DisableRenderer();
            
            Destroy(_playerBehaviour.gameObject,2);
            StartCoroutine(RespawnPlayerAfterDelay(1));
        }

        private IEnumerator RespawnPlayerAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            CreatePlayer();
        }

        public int GetScore() {
            return 666;
        }

        public void StartGame() {

            AudioManager.instance.track(2, false);
            _currentSeconds = 0 ;
            Initialize();
            _gameRunning = true;
        }
        public void EndGame()
        {

            CaclculateScore();
            _gameRunning = false;
            SceneManager.LoadScene("2_Final_Demo");
        }

        private void CaclculateScore()
        {
            int score = 0;

            foreach (interactableBehaviour interactableBehaviour in _interactableehaviours)
            {
                if (interactableBehaviour.Info.Done)
                {
                    score += interactableBehaviour.Info.Score;
                }
            }

            score += (int)(_maxSeconds - _currentSeconds);
            score *= 100;
            score -= 50 * (ScoreManager.miss);

            ScoreManager.score = score;
        }

        public bool IsInteractionDone(string name)
        {
            foreach (interactableBehaviour interactableBehaviour in _interactableehaviours)
            {
                if (interactableBehaviour.Info.Name.Equals(name))
                    return interactableBehaviour.Info.Done;
            }
            return false;
        }

    }
}

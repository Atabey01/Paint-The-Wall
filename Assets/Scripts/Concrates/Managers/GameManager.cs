using UnityEngine;
using UnityEngine.SceneManagement;
using TPSRunerGame.Abstracts;
using System;

namespace TPSRunerGame.Controllers
{
    public class GameManager : MonoBehaviour
    {
        #region Events
        public event Action OnGameBegin;
        public event Action OnGameStart;
        public event Action OnGameWin;
        public event Action OnGameOver;
        public event Action OnGameLoose;
        public event Action OnPainting;
        public event Action<int> OnPainPercentage;
        public event Action<float> OnCollectSpray;
        public event Action<float> OnSpray;
        #endregion

        public GameObject EndPoint;
        public GameObject StartPoint;
        public bool AgentStartsMove;
        LevelCreator _levelCreator;

        #region Singleton

        public static GameManager Instance { get; private set; }
        public GameStates GameState { get; private set; }
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }
        private void Start()
        {
            InitializeGameBegin();
            _levelCreator = FindObjectOfType<LevelCreator>();
            EndPoint.SetActive(true);
            AgentStartsMove = false;
        }
        #endregion

        public void InitializeGameBegin()
        {
            GameState = GameStates.InGameBegin;
            OnGameBegin?.Invoke();
        }
        public void IntializeGameStart()
        {
            GameState = GameStates.InGameStart;
            OnGameStart?.Invoke();
        }
        public void IntializeGameWin()
        {
            GameState = GameStates.InGameWin;
            OnGameWin?.Invoke();
        }
        public void InitializeGameOver()
        {
            GameState = GameStates.InGameOver;
            OnGameOver?.Invoke();
        }
        public void InitializeAgentLoose()
        {
            GameState = GameStates.InGameLoose;
            OnGameLoose?.Invoke();
        }
        public void IntializePainting()
        {
            GameState = GameStates.InPanting;
            OnPainting?.Invoke();
        }
        public void InitializeRespawn()
        {
            OnGameOver?.Invoke();
        }
        public void InitializePaintPurcentage(int percentage)
        {
            OnPainPercentage?.Invoke(percentage);
        }

        public void SprayCollected(float sprayCount)
        {
            OnCollectSpray?.Invoke(sprayCount);
        }
        
        public void OnSpraying(float spreyProgress)
        {
            OnSpray?.Invoke(spreyProgress);
        }
    }
}

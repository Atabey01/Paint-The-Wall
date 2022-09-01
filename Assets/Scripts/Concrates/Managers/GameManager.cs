using UnityEngine;
using UnityEngine.SceneManagement;
using TPSRunerGame.Abstracts;

namespace TPSRunerGame.Controllers
{
    public class GameManager : MonoBehaviour
    {
        #region Events
        public event System.Action OnGameBegin;
        public event System.Action OnGameStart;
        public event System.Action OnGameWin;
        public event System.Action OnGameOver;
        public event System.Action OnGameLoose;
        public event System.Action OnPainting;
        public event System.Action<int> OnPainPercentage;
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
            EndPoint = _levelCreator.EndPoint;
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
    }
}

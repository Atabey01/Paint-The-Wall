using UnityEngine;
using UnityEngine.SceneManagement;
using TPSRunerGame.Movements;
using TPSRunerGame.Abstracts;
using System;
using System.Collections;
using TPSRunerGame.Abstracts.Inputs;
using System.Collections.Generic;

namespace TPSRunerGame.Controllers
{
    public class PlayerController : MonoBehaviour//Subject
    {
        [SerializeField] AudioManager _audioManager;
        #region Game Element Veriables
        [Header("Game Element Veriables")]
        [SerializeField] Transform _startPoint;
        //[SerializeField] List<GameObject> _particalEffects;
        ParticleSystem effects;
        #endregion

        #region Player Movement Veriables
        [Header("Player Movement Veriables")]
        [SerializeField] float _moveSpeedX = 1f;
        [SerializeField] float _moveSpeedZ = 5f;
        [SerializeField] float _yAxisBoundary = -1.5f;
        [SerializeField] Animator _animator;
        [SerializeField] bool _agentStartMove;
        #endregion

        Rigidbody _rb;

        Mover _mover;

        InputManager _inputManager;
        AgentController _agentController;
        [SerializeField] LevelCreator _levelCreateor;

        public float MoveSpeedX { get => _moveSpeedX; private set => _moveSpeedX = value; }
        public float MoveSpeedZ { get => _moveSpeedZ; private set => _moveSpeedZ = value; }
        public bool AgentStartsMove { get => _agentStartMove; set => _agentStartMove = value; }

        private void Awake()
        {
            _mover = new Mover(this);
            _inputManager = new InputManager();
            _levelCreateor = FindObjectOfType<LevelCreator>();

        }
        private void Start()
        {

            AgentStartsMove = false;
        }
        private void OnEnable()
        {
            GameManager.Instance.OnGameBegin += StartGame;
            GameManager.Instance.OnGameOver += Respawn;
            GameManager.Instance.OnGameLoose += LooseGame;
            GameManager.Instance.OnPainting += PaintTheWall;
        }
        private void Update()
        {
            _inputManager.GetInputData();
        }
        private void FixedUpdate()
        {
            if (GameManager.Instance.GameState == Abstracts.GameStates.InGameStart)
            {
                if (Input.GetMouseButton(0))
                {
                    GameManager.Instance.AgentStartsMove = true;
                    _mover.TickFixed(_inputManager.HorizontalDirection * Time.deltaTime, _inputManager.VerticalDirection, MoveSpeedX, MoveSpeedZ);
                }

                else if (transform.position.y <= _yAxisBoundary)
                {
                    GameManager.Instance.InitializeGameOver();
                }

                if (_inputManager.VerticalDirection == 0)
                {
                    _animator.SetBool("isRun", false);
                }

                else
                {
                    _animator.SetBool("isRun", true);
                }
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                GameManager.Instance.InitializeGameOver();
            }
            else if (collision.gameObject.CompareTag("Finish"))
            {
                //gameover
                GameManager.Instance.IntializePainting();
                _audioManager.PlayWinSound();
                ShowParticalEffects();
                collision.gameObject.SetActive(false);
            }
        }
        private void OnDisable()
        {
            GameManager.Instance.OnGameBegin -= StartGame;
            GameManager.Instance.OnGameOver -= Respawn;
            GameManager.Instance.OnGameLoose -= LooseGame;
            GameManager.Instance.OnPainting -= PaintTheWall;

        }
        void StartGame()
        {
            transform.position = _startPoint.transform.position;
        }
        void Respawn()
        {
            StartCoroutine(RestartGame());
        }
        IEnumerator RestartGame()
        {
            _animator.SetBool("Death", true);
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            _animator.SetBool("Death", false);


        }
        void PaintTheWall()
        {
            StartCoroutine(PaintWall());
        }
        void ShowParticalEffects()
        {
            //foreach (GameObject effect in _levelDataSO.ParticalEffectsList)
            //{
            //    effect.GetComponent<ParticleSystem>().Play();
            //}
            _levelCreateor.effect1.GetComponent<ParticleSystem>().Play();
            _levelCreateor.effect2.GetComponent<ParticleSystem>().Play();
        }
        IEnumerator PaintWall()
        {
            _animator.SetTrigger("Victory");
            yield return new WaitForSeconds(2f);
            GameManager.Instance.IntializePainting();
        }
        void LooseGame()
        {
            _animator.SetBool("isRun", false);
        }
    }

}

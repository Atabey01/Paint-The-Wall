using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TPSRunerGame.Controllers
{
    public class UIManager : MonoBehaviour
    {
        [Header("Game Area")]
        [SerializeField] GameObject _virtualCamera;
        [SerializeField] GameObject _gameCamera;
        [SerializeField] GameObject _gameCameraPoint;
        [SerializeField] GameObject _finishLine;

        [Header("Panels")]
        [SerializeField] Text _rankText;
        [SerializeField] GameObject _startPanel;
        [SerializeField] GameObject _deathPanel;
        [SerializeField] GameObject _LoosePanel;
        [SerializeField] GameObject _winPanel;

        [Header("Painting")]
        [SerializeField] Slider _paintPercentageBar;
        [SerializeField] Text _paintPercentageText;
        [SerializeField] Texture2D _paintingCursor;
        [SerializeField] GameObject _painting;
        [SerializeField] GameObject _paintWall;
        [SerializeField] GameObject _paintingElements;
        [SerializeField] LevelCreator _levelCreator;
        [SerializeField] Slider _spreyProgressBarSlider;

        private void OnEnable()
        {
            _levelCreator = FindObjectOfType<LevelCreator>();


            GameManager.Instance.OnGameBegin += ShowStartPanel;
            GameManager.Instance.OnGameBegin += HidePainting;
            GameManager.Instance.OnGameBegin += HideRankText;
            GameManager.Instance.OnGameBegin += HideWinPanel;
            GameManager.Instance.OnGameBegin += HideLoosePanel;
            GameManager.Instance.OnGameBegin += HideDeathPanel;
            GameManager.Instance.OnGameBegin += ShowFinishLine;


            GameManager.Instance.OnGameStart += HideStartPanel;
            GameManager.Instance.OnGameStart += ShowRankText;

            GameManager.Instance.OnGameOver += ShowDeathPanel;
            GameManager.Instance.OnGameOver += HideRankText;

            GameManager.Instance.OnGameLoose += ShowLoosePanel;

            GameManager.Instance.OnPainting += ShowPainting;
            GameManager.Instance.OnPainting += HideRankText;
            GameManager.Instance.OnPainting += HideFinishLine;
            GameManager.Instance.OnPainting += ChangeCursor;

            GameManager.Instance.OnGameWin += ShowWinPanel;

            GameManager.Instance.OnPainPercentage += CalculatePaintPercentage;

            GameManager.Instance.OnCollectSpray += SpreyBarHandler;
            GameManager.Instance.OnSpray += SliderBarValueDecrease;
        }
        private void Start()
        {
            print(_levelCreator._levelDataList.Count);
        }
        private void OnDisable()
        {
            GameManager.Instance.OnGameBegin -= ShowStartPanel;
            GameManager.Instance.OnGameBegin -= HidePainting;
            GameManager.Instance.OnGameBegin -= HideRankText;
            GameManager.Instance.OnGameBegin -= HideWinPanel;
            GameManager.Instance.OnGameBegin -= HideLoosePanel;
            GameManager.Instance.OnGameBegin -= HideDeathPanel;
            GameManager.Instance.OnGameBegin -= ShowFinishLine;

            GameManager.Instance.OnGameStart -= HideStartPanel;
            GameManager.Instance.OnGameStart -= ShowRankText;

            GameManager.Instance.OnGameOver -= ShowDeathPanel;
            GameManager.Instance.OnGameOver -= HideRankText;

            GameManager.Instance.OnGameLoose -= ShowLoosePanel;

            GameManager.Instance.OnPainting -= ShowPainting;
            GameManager.Instance.OnPainting -= HideRankText;
            GameManager.Instance.OnPainting -= HideFinishLine;
            GameManager.Instance.OnPainting -= ChangeCursor;


            GameManager.Instance.OnGameWin -= ShowWinPanel;

            GameManager.Instance.OnPainPercentage -= CalculatePaintPercentage;

            GameManager.Instance.OnCollectSpray -= SpreyBarHandler;
            GameManager.Instance.OnSpray -= SliderBarValueDecrease;
        }
        private void ChangeCursor()
        {
            Cursor.visible = true;
            Vector2 cursorSize = new Vector2(_paintingCursor.width * 0.2f, _paintingCursor.height * 0.3f);
            Cursor.SetCursor(_paintingCursor, cursorSize, CursorMode.ForceSoftware);
        }
        void ShowRankText()
        {
            _rankText.enabled = true;
        }
        void HideRankText()
        {
            _rankText.enabled = false;
        }
        void ShowStartPanel()
        {
            _startPanel.SetActive(true);
            Cursor.visible = false;
        }
        void HideStartPanel()
        {
            _startPanel.SetActive(false);
        }
        void ShowPainting()
        {
            StartCoroutine(MoveGameCamera());
        }
        void HidePainting()
        {
            _levelCreator.Painting?.SetActive(false);
            _paintingElements.SetActive(false);
        }
        void ShowLoosePanel()
        {
            StartCoroutine(LooseGame());
        }
        void HideLoosePanel()
        {
            _LoosePanel.SetActive(false);
        }
        void ShowWinPanel()
        {
            _winPanel.SetActive(true);
        }
        void HideWinPanel()
        {
            _winPanel.SetActive(false);
        }
        void HideFinishLine()
        {
            _levelCreator.FinishLine.SetActive(false);
        }
        void ShowFinishLine()
        {
            _levelCreator.FinishLine.SetActive(true);
        }
        void ShowDeathPanel()
        {
            StartCoroutine(GoDie());
        }
        void HideDeathPanel()
        {
            _deathPanel.SetActive(false);
        }
        IEnumerator LooseGame()
        {
            _LoosePanel.SetActive(true);
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        IEnumerator GoDie()
        {
            _deathPanel.SetActive(true);
            yield return new WaitForSeconds(2);
            _deathPanel.SetActive(false);
        }
        IEnumerator MoveGameCamera()
        {
            yield return new WaitForSeconds(2);
            _levelCreator.Painting?.SetActive(true);
            _paintingElements?.SetActive(true);
            _virtualCamera?.SetActive(false);
            _gameCamera.transform.position = _levelCreator.Painting.transform.GetChild(0).transform.position;
            _gameCamera.transform.rotation = _levelCreator.Painting.transform.GetChild(0).transform.rotation;
        }
        void CalculatePaintPercentage(int percentage)
        {
            _paintPercentageText.enabled = true;
            _paintPercentageBar.value = percentage;
            _paintPercentageText.text = $"%{percentage} Painted";
        }
        public void TopToStartButton()
        {
            GameManager.Instance.IntializeGameStart();
        }
        public void TopToOneMoreButton()
        {
            Cursor.visible = false;

            //_levelCreator.CurrentLevel = _levelCreator._levelDataList.Count - 1 >= _levelCreator.CurrentLevel + 1 ? _levelCreator.CurrentLevel++ : _levelCreator.CurrentLevel;
            if (_levelCreator._levelDataList.Count - 1 >= _levelCreator.CurrentLevel + 1)
            {
                _levelCreator.CurrentLevel++;
                print(_levelCreator.CurrentLevel);
            }
            else
            {

            }


            PlayerPrefs.SetInt("CurrentLevel", _levelCreator.CurrentLevel);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void QuitButton()
        {
            Application.Quit();
        }

        public void SpreyBarHandler(float spreyCount)
        {
            _spreyProgressBarSlider.value = spreyCount;
        }

        public void SliderBarValueDecrease(float decreaseRate)
        {
            _spreyProgressBarSlider.value -= decreaseRate;
            if (_spreyProgressBarSlider.value == 0)
            {
                GameManager.Instance.InitializeGameOver();
            }
        }
    }
}

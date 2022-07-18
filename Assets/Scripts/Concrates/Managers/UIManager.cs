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
        [SerializeField] GameObject _painting;
        [SerializeField] GameObject _paintWall;
        [SerializeField] GameObject _paintingElements;        
        private void OnEnable()
        {
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

            GameManager.Instance.OnGameWin += ShowWinPanel;

            GameManager.Instance.OnPainPercentage += CalculatePaintPercentage;
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

            GameManager.Instance.OnGameWin -= ShowWinPanel;

            GameManager.Instance.OnPainPercentage -= CalculatePaintPercentage;
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
            _painting.SetActive(false);
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
            _finishLine.SetActive(false);
        }
        void ShowFinishLine()
        {
            _finishLine.SetActive(true);
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
            _painting.SetActive(true);
            _paintingElements.SetActive(true);
            _virtualCamera.SetActive(false);
            _gameCamera.transform.position = _gameCameraPoint.transform.position;
            _gameCamera.transform.rotation = _gameCameraPoint.transform.rotation;
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void QuitButton()
        {
            Application.Quit();
        }


    }
}

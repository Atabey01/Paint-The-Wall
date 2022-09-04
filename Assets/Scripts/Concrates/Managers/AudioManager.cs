using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TPSRunerGame.Controllers;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource _spraySound;
    [SerializeField] AudioSource _buttonClickSound;
    [SerializeField] AudioSource _sprayCollectSound;
    [SerializeField] AudioSource _gameMusic;
    [SerializeField] AudioSource _failSound;
    [SerializeField] AudioSource _winSound;


    void OnEnable()
    {
        GameManager.Instance.OnSpray += PlaySpraySound;
        GameManager.Instance.OnCollectSpray += PlaySprayCollectSound;
        GameManager.Instance.OnGameLoose += PlayFailSound;
        GameManager.Instance.OnGameOver += PlayFailSound;
    }

    void OnDisable()
    {
        GameManager.Instance.OnSpray -= PlaySpraySound;
        GameManager.Instance.OnCollectSpray -= PlaySprayCollectSound;
        GameManager.Instance.OnGameLoose -= PlayFailSound;
        GameManager.Instance.OnGameOver -= PlayFailSound;
    }

    void Update()
    {
        if (!Input.GetMouseButtonUp(0))
            return;
        if (_spraySound.isPlaying)
            _spraySound.Stop();
    }

    void PlaySpraySound(float empty)
    {
        if (!_spraySound.isPlaying)
            _spraySound.Play();
    }

    void PlaySprayCollectSound(float empty)
    {
        _sprayCollectSound.Play();
    }

    void PlayFailSound()
    {
        _gameMusic.Stop();
        _failSound.Play();
    }

    public void PlayWinSound()
    {
        _gameMusic.Stop();
        _winSound.Play();
    }

    public void PlayButtonClickSound()
    {
        _buttonClickSound.Play();
    }
}

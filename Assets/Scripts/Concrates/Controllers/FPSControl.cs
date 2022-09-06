using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSControl : MonoBehaviour
{
    public Text FpsText;
    public Text CurrentLevel;
    public float DeltaTime;

    void Start()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
        CurrentLevel.text = "Level:" + (PlayerPrefs.GetInt("CurrentLevel") + 1).ToString();
    }
    void Update()
    {
        DeltaTime += (Time.deltaTime - DeltaTime) * 0.1f;
        float fps = 1.0f / DeltaTime;
        FpsText.text = "FPS:" + Mathf.Ceil(fps).ToString();
    }
}

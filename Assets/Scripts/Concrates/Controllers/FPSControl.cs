using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSControl : MonoBehaviour
{
    public Text fpsText;
    public float deltaTime;

    void Start()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
    }
    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil(fps).ToString();
    }
}

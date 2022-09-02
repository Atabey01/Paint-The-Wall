using System.Collections;
using System.Collections.Generic;
using TPSRunerGame.Abstracts;
using TPSRunerGame.Controllers;
using UnityEngine;

public class Painting : MonoBehaviour
{

    [SerializeField] float _brushSize;
    [SerializeField] Camera _paintingCamera;
    [SerializeField] GameObject _brush;
    [SerializeField] GameObject _BrushParent;
    [SerializeField] Transform _rendererWall;
    [SerializeField] RenderTexture _wallRenderTexture;
    [SerializeField] int _objectPoolSize = 2000;
    [SerializeField] float _decreaseRate = 0.01f;

    Vector3 _distanceBetweenWalls;

    Queue<GameObject> _objectPool;

    int _basePixels = 0;
    int _paintedPixels = 0;

    void Awake()
    {
        _objectPool = new Queue<GameObject>(); // Creating A Queue For Object Pool

        ObjectPooling();
    }
    void Start()
    {
        _distanceBetweenWalls = _rendererWall.transform.position - transform.position;
    }
    void FixedUpdate()
    {
        if (GameManager.Instance.GameState == GameStates.InPanting)
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Casting A Ray From Screen To Wall
                RaycastHit hit;
                Vector3 brushPosition = Vector3.zero;

                if (Physics.Raycast(ray, out hit))
                {
                    MeshCollider meshCollider = hit.collider as MeshCollider;
                    if (meshCollider == null)
                        return;

                    brushPosition = hit.point + _distanceBetweenWalls;

                    GameObject brushClone = GetPooledObject();

                    brushClone.transform.localPosition = brushPosition; // Locate The Brush Position
                    brushClone.transform.localScale = Vector3.one * _brushSize; //Creating A Brush Size To Change Later
                    brushClone.transform.rotation = hit.transform.rotation;

                    CalculatedPercentage();
                    GameManager.Instance.OnSpraying(_decreaseRate);
                }
            }
        }
    }
    void CalculatedPercentage()
    {
        GameManager.Instance.InitializePaintPurcentage(CalculatePaintingPercentage());
    }
    int CalculatePaintingPercentage()
    {
        RenderTexture.active = _wallRenderTexture; //Activating Unity Render Engine And Creat Texture For The "_wallRenderTexture" 

        Texture2D renderTexture2D = new Texture2D(_wallRenderTexture.width, _wallRenderTexture.height);//Creating A Texture2D 

        renderTexture2D.ReadPixels(new Rect(0, 0, _wallRenderTexture.width, _wallRenderTexture.height), 0, 0);//Reading The Pixels Of The Created Texture
        renderTexture2D.Apply();//Get Pixels Informations

        RenderTexture.active = null;// Deactivating The Unity Render Engine 

        _basePixels = renderTexture2D.width * renderTexture2D.height;//Mathematical Calculation OF The Texture Area(Pixel Count Inside Of It)
        _paintedPixels = 0;

        Color[] basePixelColors = renderTexture2D.GetPixels();//Get The Information Of How Many Red Pixels Are In The Texture


        foreach (Color pixelColor in basePixelColors)
        {
            if (pixelColor.b <= 0.1f)//White RGB = (1,1,1)---Red(1,0,0) So, We Are Looking For Red Pixels. That Means We Need To Find RGB's B(Blue) = 0
            {
                _paintedPixels++;
            }
        }

        int percentage = Mathf.CeilToInt(_paintedPixels * 100 / basePixelColors.Length);

        if (percentage >= 99f)
        {
            GameManager.Instance.IntializeGameWin();
        }

        //print(percentage);
        return percentage + 1;
    }

    void ObjectPooling()
    {
        for (int i = 0; i < _objectPoolSize; i++)
        {
            GameObject brushClone = Instantiate(_brush);
            brushClone.SetActive(false);
            _objectPool.Enqueue(brushClone);
        }
    }

    GameObject GetPooledObject()
    {
        GameObject brushClone = _objectPool.Dequeue();

        brushClone.SetActive(true);

        _objectPool.Enqueue(brushClone);

        return brushClone;

    }
}

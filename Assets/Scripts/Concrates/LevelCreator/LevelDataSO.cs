using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Data", menuName = "ScriptableObject/Level Data")]
public class LevelDataSO : ScriptableObject
{
    #region Obstacle Data
    [Header("Obstacle Data")]
    //public ObstaclesSO ObstaclesSO;

    [SerializeField] List<GameObject> _horizontalObstacle;
    [SerializeField] List<int> _horizontalObstacleDestinationList;
    public List<GameObject> HorizontalObstacle { get => _horizontalObstacle; set => _horizontalObstacle = value; }
    public List<int> HorizontalObstacleDestinationList { get => _horizontalObstacleDestinationList; set => _horizontalObstacleDestinationList = value; } 
    #endregion

    #region Platforms
    [Header("Platforms Data")]
    //public  PlatformsSO PlatformsSO;
    [SerializeField] List<GameObject> _platforms;
    [SerializeField] List<int> _platformsDestinationList;
    public List<GameObject> Platforms { get => _platforms; set => _platforms = value; }
    public List<int> PlatformsDestinationList { get => _platformsDestinationList; set => _platformsDestinationList = value; }
    #endregion

    #region Painting Data
    [Header("Painting Data")]
    //public  PaintingSO PaintingSO;

    [SerializeField] int _paintingDistance;
    [SerializeField] List<GameObject> _painting;

    public int PaintingDistance { get => _paintingDistance; set => _paintingDistance = value; }
    public List<GameObject> Painting { get => _painting; set => _painting = value; } 
    #endregion

    #region Finish Line
    [Header("Finish Line Data")]
    //public  FinishLineSO FinishLineSO;
    [SerializeField] GameObject _finishLine;
    [SerializeField] GameObject effect1;
    [SerializeField] float effect1DestinationX;
    [SerializeField] float effect1DestinationY;
    [SerializeField] float effect2DestinationX;
    [SerializeField] float effect2DestinationY;
    [SerializeField] GameObject effect2;
    [SerializeField] GameObject _endPoint;
    [SerializeField] List<int> _FinishLineDestinationList;
    public List<int> FinishLineDestinationList { get => _FinishLineDestinationList; set => _FinishLineDestinationList = value; }
    public GameObject FinishLine { get => _finishLine; set => _finishLine = value; }
    public GameObject GameEndPoint { get => _endPoint; set => _endPoint = value; }
    public GameObject Effect1 { get => effect1; set => effect1 = value; }
    public GameObject Effect2 { get => effect2; set => effect2 = value; }
    public float Effect1DestinationX { get => effect1DestinationX; set => effect1DestinationX = value; }
    public float Effect1DestinationY { get => effect1DestinationY; set => effect1DestinationY = value; }
    public float Effect2DestinationX { get => effect2DestinationX; set => effect2DestinationX = value; }
    public float Effect2DestinationY { get => effect2DestinationY; set => effect2DestinationY = value; }
    #endregion

    #region Rotating Platform
    [Header("Rotating Platform Data")]
    //public RotatingPlatformSO RotatingPlatformSO;

    [SerializeField] List<GameObject> _rotatingPlatform;

    [SerializeField] float _rotatingPlatformDestinationX;
    [SerializeField] float _rotatingPlatformDestinationY;
    [SerializeField] float _rotatingPlatformDestinationZ;


    public List<GameObject> RotatingPlatform { get => _rotatingPlatform; set => _rotatingPlatform = value; }
    public float RotatingPlatformDestinationX { get => _rotatingPlatformDestinationX; set => _rotatingPlatformDestinationX = value; }
    public float RotatingPlatformDestinationY { get => _rotatingPlatformDestinationY; set => _rotatingPlatformDestinationY = value; }
    public float RotatingPlatformDestinationZ { get => _rotatingPlatformDestinationZ; set => _rotatingPlatformDestinationZ = value; }
    #endregion

    #region Donut Data
    [Header("Donut")]
    [SerializeField] List<GameObject> _donut;
    [SerializeField] float _donutDestination;

    public List<GameObject> Donut { get => _donut; set => _donut = value; }
    public float DonutDestination { get => _donutDestination; set => _donutDestination = value; }

    #endregion
}

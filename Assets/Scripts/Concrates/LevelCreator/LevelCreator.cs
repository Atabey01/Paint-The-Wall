using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] List<GameObject> _horizontalObstacleList;
    [SerializeField] List<GameObject> _platformList;
    [SerializeField] List<NavMeshSurface> _navMeshSurfaces;

    public List<LevelDataSO> _levelDataList;
    public GameObject Painting;
    public GameObject RotatingPlatform;
    public GameObject Donut;
    public GameObject FinishLine;
    public GameObject effect1;
    public GameObject effect2;
    public static GameObject EndPoint;
    public int CurrentLevel;


    void Awake()
    {
        // PlayerPrefs.DeleteAll();
        CurrentLevel = PlayerPrefs.HasKey("CurrentLevel") ? PlayerPrefs.GetInt("CurrentLevel") : 0;
    }
    private void Start()
    {
        print(CurrentLevel);
        LevelInitialize();

    }
    void LevelInitialize()
    {
        #region Painting
        if (_levelDataList[CurrentLevel].Painting.Count != 0)
        {
            Painting = Instantiate(_levelDataList[CurrentLevel].Painting[0]);
            Painting.transform.position = new Vector3(0, 0, _levelDataList[CurrentLevel].PaintingDistance);
        }
        #endregion

        #region Horizontal Obstacle
        if (_levelDataList[CurrentLevel].HorizontalObstacle.Count != 0)
        {
            foreach (var obstacle in _levelDataList[CurrentLevel].HorizontalObstacle)
            {
                GameObject horizontalObsClone = Instantiate(obstacle);
                _horizontalObstacleList.Add(horizontalObsClone);

            }
            for (int i = 0; i < _horizontalObstacleList.Count; i++)
            {
                _horizontalObstacleList[i].transform.position = new Vector3(0, 2.8f, _levelDataList[CurrentLevel].HorizontalObstacleDestinationList[i]);
            }
        }

        #endregion

        #region Platforms
        if (_levelDataList[CurrentLevel].Platforms.Count != 0)
        {
            foreach (var platforms in _levelDataList[CurrentLevel].Platforms)
            {
                GameObject platform = Instantiate(platforms);
                _platformList.Add(platform);
                _navMeshSurfaces.Add(platform.GetComponent<NavMeshSurface>());
            }
            for (int i = 0; i < _platformList.Count; i++)
            {
                _platformList[i].transform.position = new Vector3(0, 0, _levelDataList[CurrentLevel].PlatformsDestinationList[i]);
            }
        }
        #endregion

        #region Finish Line
        if (_levelDataList[CurrentLevel].FinishLine != null)
        {
            FinishLine = Instantiate(_levelDataList[CurrentLevel].FinishLine);

            EndPoint = Instantiate(_levelDataList[CurrentLevel].GameEndPoint);
            effect1 = Instantiate(_levelDataList[CurrentLevel].Effect1);
            effect2 = Instantiate(_levelDataList[CurrentLevel].Effect2);

            FinishLine.transform.position = new Vector3(0, 0, _levelDataList[CurrentLevel].FinishLineDestinationList[0]);

            effect1.transform.position = new Vector3(_levelDataList[CurrentLevel].Effect1DestinationX, _levelDataList[CurrentLevel].Effect1DestinationY, FinishLine.transform.position.z);
            effect2.transform.position = new Vector3(_levelDataList[CurrentLevel].Effect2DestinationX, _levelDataList[CurrentLevel].Effect2DestinationY, FinishLine.transform.position.z);

            EndPoint.transform.position = FinishLine.transform.position;
        }
        #endregion

        #region Donut
        if (_levelDataList[CurrentLevel].Donut.Count != 0)
        {
            Donut = Instantiate(_levelDataList[CurrentLevel].Donut[0]);
            Donut.transform.position = new Vector3(0, 0, _levelDataList[CurrentLevel].DonutDestination);
        }
        #endregion

        #region Rotating Platform
        if (_levelDataList[CurrentLevel].RotatingPlatform.Count != 0)
        {
            RotatingPlatform = Instantiate(_levelDataList[CurrentLevel].RotatingPlatform[0]);
            RotatingPlatform.transform.position = new Vector3(_levelDataList[CurrentLevel].RotatingPlatformDestinationX, _levelDataList[CurrentLevel].RotatingPlatformDestinationY, _levelDataList[CurrentLevel].RotatingPlatformDestinationZ);
        }
        #endregion

        #region Bake NavMesh
        for (int i = 0; i < _navMeshSurfaces.Count; i++)
        {
            _navMeshSurfaces[i].BuildNavMesh();
        }
        #endregion

        if (_levelDataList[CurrentLevel].Sprays.Count != 0)
        {
            for (int i = 0; i < _levelDataList[CurrentLevel].Sprays.Count - 2; i++)
            {
                if (_levelDataList[CurrentLevel].Sprays[i] == null)
                    _levelDataList[CurrentLevel].Sprays[i] = _levelDataList[CurrentLevel].Sprays[i - 1];
                Vector3 spreyPos = _levelDataList[CurrentLevel].Platforms[i].GetComponent<MeshRenderer>().bounds.size.x
                 / 2 * Random.Range(-1f, 1f) * Vector3.right;
                GameObject spreyClone = Instantiate(_levelDataList[CurrentLevel].Sprays[i], spreyPos + new Vector3(0, _levelDataList[CurrentLevel].Sprays[i].GetComponent<MeshRenderer>().bounds.size.y, _platformList[i + 1].transform.position.z), Quaternion.identity);
            }
        }
    }
}

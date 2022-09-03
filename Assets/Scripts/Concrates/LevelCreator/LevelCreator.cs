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
    public GameObject RotatingPlatformList;
    public GameObject Donut;
    public GameObject FinishLine;
    public GameObject effect1;
    public GameObject effect2;
    public static GameObject EndPoint;
    public int CurrentLevel;

    float _totalDistance = -4;
    bool _isNewLevel;


    void Awake()
    {
        // PlayerPrefs.DeleteAll();
        CurrentLevel = PlayerPrefs.HasKey("CurrentLevel") ? PlayerPrefs.GetInt("CurrentLevel") : 0;
    }
    private void Start()
    {
        LevelInitialize();

    }
    void LevelInitialize()
    {
        if (CurrentLevel + 1 > 2)
        {
            _isNewLevel = true;
            _levelDataList[CurrentLevel] = NewLevel();
            InitializeExistLevelObjects();
        }
        else
        {
            _isNewLevel = false;
            InitializeExistLevelObjects();
        }
        InitializeDefaultLevelObjects();
    }

    LevelDataSO NewLevel()
    {
        LevelDataSO newLevel = Instantiate(_levelDataList[1]);
        List<GameObject> allPlatforms = new List<GameObject>((CurrentLevel + 1) * 4);

        GameObject platform = _levelDataList[1].PlatformList[0];
        GameObject rotatingPlatform = _levelDataList[1].RotatingPlatformList[0];

        newLevel.PlatformList = new List<GameObject>();
        for (int i = 0; i < Mathf.CeilToInt((CurrentLevel + 1) * 4 * 3 / 4); i++)
        {
            GameObject platformInstance = Instantiate(platform, Vector3.zero, Quaternion.identity);
            allPlatforms.Add(platformInstance);
            _navMeshSurfaces.Add(platformInstance.GetComponent<NavMeshSurface>());
        }

        newLevel.RotatingPlatformList = new List<GameObject>();
        for (int j = 0; j < Mathf.FloorToInt((CurrentLevel + 1) * 4 / 4); j++)
        {
            GameObject rotatingPlatformInstance = Instantiate(rotatingPlatform, new Vector3(0, -rotatingPlatform.GetComponent<MeshRenderer>().bounds.size.y / 2, 0), Quaternion.identity);
            allPlatforms.Add(rotatingPlatformInstance);
        }

        GameObject lastPlatform = null;
        for (int k = 0; k < allPlatforms.Count; k++)
        {
            int randomIndex = Random.Range(0, allPlatforms.Count);
            if (lastPlatform == null)
                lastPlatform = platform;

            if (allPlatforms[randomIndex].gameObject.name == "RotatingPlatform(Clone)" && allPlatforms.Count == (CurrentLevel + 1) * 4)
            {
                _totalDistance += allPlatforms[0].GetComponent<MeshRenderer>().bounds.size.z;
                allPlatforms[0].transform.position = new Vector3(allPlatforms[0].transform.position.x, allPlatforms[0].transform.position.y, _totalDistance);

                lastPlatform = allPlatforms[0];
                if (allPlatforms[0].gameObject.name == "Plane(Clone)")
                    newLevel.PlatformList.Add(allPlatforms[0]);
                else
                    newLevel.RotatingPlatformList.Add(allPlatforms[0]);
                allPlatforms.RemoveAt(0);
            }
            else
            {
                if (allPlatforms[randomIndex].gameObject.name == "RotatingPlatform(Clone)" && allPlatforms.Count == 1)
                {
                    Destroy(allPlatforms[randomIndex]);
                    allPlatforms[randomIndex] = Instantiate(platform, Vector3.zero, Quaternion.identity);
                    _navMeshSurfaces.Add(allPlatforms[randomIndex].GetComponent<NavMeshSurface>());
                }
                _totalDistance += lastPlatform.GetComponent<MeshRenderer>().bounds.size.z / 2 + allPlatforms[randomIndex].GetComponent<MeshRenderer>().bounds.size.z / 2 - .5f;
                allPlatforms[randomIndex].transform.position = new Vector3(allPlatforms[randomIndex].transform.position.x, allPlatforms[randomIndex].transform.position.y, _totalDistance);

                lastPlatform = allPlatforms[randomIndex];
                if (allPlatforms[randomIndex].gameObject.name == "Plane(Clone)")
                    newLevel.PlatformList.Add(allPlatforms[randomIndex]);
                else
                    newLevel.RotatingPlatformList.Add(allPlatforms[randomIndex]);
                allPlatforms.RemoveAt(randomIndex);
            }



            k -= 1;
        }

        newLevel.FinishLine.transform.position = lastPlatform.transform.position;
        newLevel.GameEndPoint.transform.position = lastPlatform.transform.position;
        newLevel.Sprays = new List<GameObject>(new GameObject[newLevel.PlatformList.Count]);
        newLevel.Painting[0].transform.position = newLevel.FinishLine.transform.position;
        for (int i = 0; i < newLevel.Sprays.Count; i++)
        {
            newLevel.Sprays[i] = _levelDataList[1].Sprays[0];
        }

        return newLevel;
    }

    void InitializeDefaultLevelObjects()
    {
        #region Painting
        if (_levelDataList[CurrentLevel].Painting.Count != 0)
        {
            Painting = Instantiate(_levelDataList[CurrentLevel].Painting[0]);
            if (_isNewLevel == false)
                Painting.transform.position = new Vector3(0, 0, _levelDataList[CurrentLevel].PaintingDistance);

            SprayProgressController.CurrentSprayCount = 0;
        }
        #endregion

        #region Finish Line
        if (_levelDataList[CurrentLevel].FinishLine != null)
        {
            FinishLine = Instantiate(_levelDataList[CurrentLevel].FinishLine);

            EndPoint = Instantiate(_levelDataList[CurrentLevel].GameEndPoint);
            effect1 = Instantiate(_levelDataList[CurrentLevel].Effect1);
            effect2 = Instantiate(_levelDataList[CurrentLevel].Effect2);

            if (_isNewLevel == false)
            {
                FinishLine.transform.position = new Vector3(0, 0, _levelDataList[CurrentLevel].FinishLineDestinationList[0]);
                EndPoint.transform.position = FinishLine.transform.position;
            }

            effect1.transform.position = new Vector3(-6, 4.5f, FinishLine.transform.position.z);
            effect2.transform.position = new Vector3(+6, 4.5f, FinishLine.transform.position.z);

        }
        #endregion
    }

    void InitializeExistLevelObjects()
    {
        #region Horizontal Obstacle
        if (_levelDataList[CurrentLevel].HorizontalObstacle.Count != 0)
        {
            foreach (var obstacle in _levelDataList[CurrentLevel].HorizontalObstacle)
            {
                GameObject horizontalObsClone = Instantiate(obstacle);
                _horizontalObstacleList.Add(horizontalObsClone);

            }
            if (_isNewLevel == false)
                for (int i = 0; i < _horizontalObstacleList.Count; i++)
                {
                    _horizontalObstacleList[i].transform.position = new Vector3(0, 2.8f, _levelDataList[CurrentLevel].HorizontalObstacleDestinationList[i]);
                }
        }

        #endregion

        #region PlatformList
        if (_levelDataList[CurrentLevel].PlatformList.Count != 0 && _isNewLevel == false)
        {
            foreach (var platforms in _levelDataList[CurrentLevel].PlatformList)
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

        #region Rotating Platform
        if (_levelDataList[CurrentLevel].RotatingPlatformList.Count != 0 && _isNewLevel == false)
        {
            RotatingPlatformList = Instantiate(_levelDataList[CurrentLevel].RotatingPlatformList[0]);
            RotatingPlatformList.transform.position = new Vector3(_levelDataList[CurrentLevel].RotatingPlatformDestinationX, _levelDataList[CurrentLevel].RotatingPlatformDestinationY, _levelDataList[CurrentLevel].RotatingPlatformDestinationZ);
        }
        #endregion

        #region Donut
        if (_levelDataList[CurrentLevel].Donut.Count != 0)
        {
            Donut = Instantiate(_levelDataList[CurrentLevel].Donut[0]);
            if (_isNewLevel == false)
                Donut.transform.position = new Vector3(0, 0, _levelDataList[CurrentLevel].DonutDestination);
        }
        #endregion
        if (_isNewLevel == true)
            _platformList = _levelDataList[CurrentLevel].PlatformList;

        if (_levelDataList[CurrentLevel].Sprays.Count != 0)
        {
            for (int i = 0; i < _levelDataList[CurrentLevel].PlatformList.Count - 2; i++)
            {
                Vector3 spreyPos = _levelDataList[CurrentLevel].PlatformList[i].GetComponent<MeshRenderer>().bounds.size.x
                 / 2 * Random.Range(-0.75f, 0.75f) * Vector3.right;

                Debug.Log(_levelDataList[CurrentLevel].Sprays[i]);

                GameObject spreyClone = Instantiate(_levelDataList[CurrentLevel].Sprays[i],
                 spreyPos + new Vector3(0, _levelDataList[CurrentLevel].Sprays[i].GetComponent<MeshRenderer>().bounds.size.y / 2, _platformList[i + 1].transform.position.z),
                   _levelDataList[CurrentLevel].Sprays[i].transform.rotation);

            }
        }

        #region Bake NavMesh
        _navMeshSurfaces[0].BuildNavMesh();
        #endregion
    }
}

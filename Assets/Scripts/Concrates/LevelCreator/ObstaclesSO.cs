using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Obctacles Data", menuName = "ScriptableObject/Level Desing/Obctacles Data")]

public class ObstaclesSO : ScriptableObject
{
    #region Horizontal Obstacle
    [Header("Horizontal Obstacle")]

    [SerializeField] List<GameObject> _horizontalObstacle;
    [SerializeField] List<int> _horizontalObstacleDestinationList;
    public List<GameObject> HorizontalObstacle { get => _horizontalObstacle; set => _horizontalObstacle = value; }
    public List<int> HorizontalObstacleDestinationList { get => _horizontalObstacleDestinationList; set => _horizontalObstacleDestinationList = value; }

    #endregion
}

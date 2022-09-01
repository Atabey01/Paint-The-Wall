using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Static Walls Data", menuName = "ScriptableObject/Level Desing/Static Walls Data")]

public class StaticWallSO : ScriptableObject
{
    #region Static Walls
    [Header("Static Wals")]
    [SerializeField] List<GameObject> _staticWalls;
    [SerializeField] List<int> _staticWallsDestination;

    public List<GameObject> StaticWalls { get => _staticWalls; set => _staticWalls = value; }
    public List<int> StaticWallsDestination { get => _staticWallsDestination; set => _staticWallsDestination = value; }
    #endregion
}

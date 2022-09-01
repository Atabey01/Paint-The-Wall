using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FinisLine Data", menuName = "ScriptableObject/Level Desing/FinisLine Data")]

public class FinishLineSO : ScriptableObject
{
    #region Finish Line
    [Header("Finis Line")]
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
}

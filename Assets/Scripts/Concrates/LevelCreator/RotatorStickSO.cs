using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rotator Stick Data", menuName = "ScriptableObject/Level Desing/Rotator Stick Data")]

public class RotatorStickSO : ScriptableObject
{
    #region Rotator Stick
    [Header("Rotator Sticks")]
    [SerializeField] List<GameObject> _rotatorStick;

    [SerializeField] List<int> _rotatorStickDestinationX;
    [SerializeField] List<int> _rotatorStickDestinationY;
    [SerializeField] List<int> _rotatorStickDestinationZ;

    public List<GameObject> RotatorStick { get => _rotatorStick; set => _rotatorStick = value; }
    public List<int> RotatorStickDestinationX { get => _rotatorStickDestinationX; set => _rotatorStickDestinationX = value; }
    public List<int> RotatorStickDestinationY { get => _rotatorStickDestinationY; set => _rotatorStickDestinationY = value; }
    public List<int> RotatorStickDestinationZ { get => _rotatorStickDestinationZ; set => _rotatorStickDestinationZ = value; } 
    #endregion
}

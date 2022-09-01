using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rotating Platforms Data", menuName = "ScriptableObject/Level Desing/Rotating Platforms Data")]

public class RotatingPlatformSO : ScriptableObject
{
    #region Rotating Platform
    [Header("Platforms")]

    [SerializeField] List<GameObject> _rotatingPlatform;

    [SerializeField] float _rotatingPlatformDestinationX;
    [SerializeField] float _rotatingPlatformDestinationY;
    [SerializeField] float _rotatingPlatformDestinationZ;


    public List<GameObject> RotatingPlatform { get => _rotatingPlatform; set => _rotatingPlatform = value; }
    public float RotatingPlatformDestinationX { get => _rotatingPlatformDestinationX; set => _rotatingPlatformDestinationX = value; }
    public float RotatingPlatformDestinationY { get => _rotatingPlatformDestinationY; set => _rotatingPlatformDestinationY = value; }
    public float RotatingPlatformDestinationZ { get => _rotatingPlatformDestinationZ; set => _rotatingPlatformDestinationZ = value; }
    #endregion
}

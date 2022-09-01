using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Platform Data", menuName = "ScriptableObject/Level Desing/Platform Data")]

public class PlatformsSO : ScriptableObject
{
    #region Platforms
    [Header("Platforms")]
    [SerializeField] List<GameObject> _platforms;
    [SerializeField] List<int> _platformsDestinationList;
    public List<GameObject> Platforms { get => _platforms; set => _platforms = value; }
    public List<int> PlatformsDestinationList { get => _platformsDestinationList; set => _platformsDestinationList = value; }
    #endregion
}

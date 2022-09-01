using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level2 Data", menuName = "ScriptableObject/Level2 Data")]


public class LevelDataSO2 : ScriptableObject
{
    [Header("Obstacle Data")]
    public ObstaclesSO ObstaclesSO;

    [Header("Platforms Data")]
    public PlatformsSO PlatformsSO;

    [Header("Painting Data")]
    public PaintingSO PaintingSO;

    [Header("Finish Line Data")]
    public FinishLineSO FinishLineSO;

    [Header("Rotating Platform Data")]
    public RotatingPlatformSO RotatingPlatformSO;

    [Header("Donut Data")]
    public DonutSO DonutSO;


}

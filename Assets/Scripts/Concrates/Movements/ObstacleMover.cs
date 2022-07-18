using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Obstacle Controller", menuName = "ScriptableObject/Obstacle")]

public class ObstacleMover : ScriptableObject
{
    #region Movements Veriables
    public float MoveSpeed = 2f;
    public float MoveX = 10f;
    #endregion

    #region  Rotatiton Veraibles
    public float RotateTime = 5f;
    public float RotateAngleY = 360f;
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "Half Donut Controller", menuName = "ScriptableObject/Half Donut")]

public class HalfDonutMover : ScriptableObject
{
    #region Movements Veriables
    public float _moveSpeed = 2f;
    public float _moveX = -0.001f;
    public Ease _ease = Ease.Linear;
    #endregion
}

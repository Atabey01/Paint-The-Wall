using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[CreateAssetMenu(fileName = "Rotation Controller", menuName = "ScriptableObject/Rotation Stick")]

public class RotatingStick : ScriptableObject
{ 
    public Vector3 _torque = new Vector3(0, 0, 200);   
}

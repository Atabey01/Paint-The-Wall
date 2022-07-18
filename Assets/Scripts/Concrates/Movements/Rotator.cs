using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rotate Platform", menuName = "ScriptableObject/Rotate")]
public class Rotator : ScriptableObject
{

    #region  Rotatiton Veraibles
    public Vector3 _torque = new Vector3(0, 0, 200);
    #endregion
   

}

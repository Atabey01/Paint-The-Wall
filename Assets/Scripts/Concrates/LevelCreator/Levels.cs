using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "All Level Datas", menuName = "ScriptableObject/Level Datas")]

public class Levels : ScriptableObject
{
    public List<ScriptableObject> _levelDataList;
    public PaintingSO PaintingSO;

}

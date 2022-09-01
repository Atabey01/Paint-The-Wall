using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Painting Data", menuName = "ScriptableObject/Level Desing/Painting Data")]

public class PaintingSO : ScriptableObject
{
    #region MyRegion
    [Header("Painting")]
    [SerializeField] int _paintingDistance;
    [SerializeField] List<GameObject> _painting;

    public int PaintingDistance { get => _paintingDistance; set => _paintingDistance = value; }
    public List<GameObject> Painting { get => _painting; set => _painting = value; }

    #endregion
}

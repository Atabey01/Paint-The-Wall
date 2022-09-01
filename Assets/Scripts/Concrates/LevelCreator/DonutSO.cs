using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Donut Data", menuName = "ScriptableObject/Level Desing/Donut Data")]

public class DonutSO : ScriptableObject
{
    #region Donut Data
    [Header("Donut")]
    [SerializeField] List<GameObject> _donut;
    [SerializeField] float _donutDestination;

    public List<GameObject> Donut { get => _donut; set => _donut = value; }
    public float DonutDestination { get => _donutDestination; set => _donutDestination = value; }

    #endregion
}

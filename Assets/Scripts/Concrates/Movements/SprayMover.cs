using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SprayMover : MonoBehaviour
{
    [SerializeField] Ease _sprayEase = Ease.InOutQuart;
    [SerializeField] float _duration = 0.5f;
    [SerializeField] float _yDistance = 0.5f;

    void Start()
    {
        gameObject.transform.DOMoveY(transform.position.y + _yDistance, _duration).SetLoops(-1, LoopType.Yoyo).SetEase(_sprayEase);
    }
}

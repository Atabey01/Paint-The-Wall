using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HalfDonutController : MonoBehaviour
{
    [SerializeField] HalfDonutMover _halfDonutMover;

    private void Start()
    {
        transform.DOMove(new Vector3(transform.position.x + _halfDonutMover._moveX, transform.position.y, transform.position.z), _halfDonutMover._moveSpeed).SetEase(_halfDonutMover._ease).SetLoops(-1, LoopType.Yoyo);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] ObstacleMover _obstacleMover;

    private void Start()
    {
        transform.DOMove(new Vector3(_obstacleMover.MoveX, transform.position.y, transform.position.z), _obstacleMover.MoveSpeed).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        transform.DORotate(new Vector3(0, _obstacleMover.RotateAngleY, 0), _obstacleMover.RotateTime, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }
}

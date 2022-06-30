using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SuperShotText : MonoBehaviour
{
    Vector2 startPos;
    [SerializeField] float miktar;
    void Awake()
    {
        startPos = transform.position;
    }

    void OnEnable()
    {
        transform.DOMove(new Vector2(startPos.x, startPos.y + miktar), 1).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
    private void OnDisable()
    {
        transform.position = startPos;
    }
}

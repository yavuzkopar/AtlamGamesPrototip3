using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBehaviour : MonoBehaviour
{
    [SerializeField] float miktar;
    void Start()
    {
        transform.DOLocalMove(new Vector3(0, miktar,0), 1).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
    private void Update()
    {
        transform.Rotate(Vector3.up,- 90 * Time.deltaTime,Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ParticleSystem obj = GameManager.Instance.goldTakeVfx;
            GameManager.Instance.gold++;
            obj.transform.position = transform.position;
            obj.gameObject.SetActive(true);
            GameManager.Instance.goldicon.SetActive(true);
            gameObject.SetActive(false);
        }
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AstroidRotation : MonoBehaviour
{
    [SerializeField] GameObject vfx;
    public void Move(Vector3 hedef,float time)
    {
        transform.DOMove(hedef, time).OnComplete(() => transform.position =transform.position + Vector3.up * 50);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.one * 45 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            vfx.transform.position = transform.position;
            vfx.SetActive(true);
        }
        }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITweens : MonoBehaviour
{
    
    [SerializeField] Transform hedef;
    [SerializeField] Transform hedef1;
    [SerializeField]float lerpvalue = 0;
    // Update is called once per frame
    Vector3 p;
    Vector3 pos;
 


    private void OnEnable()
    {
        // lerpe çevrilecek daha iyi öyle
        transform.DOScale(Vector3.one, 1);
        p = transform.localPosition;
      /*  transform.DOLocalMove(hedef1.localPosition, 1).OnComplete(() => 
        { transform.DOLocalMove(hedef.localPosition, 1).OnComplete(Deactive); });*/
    /* Vector3 a = Vector3.Lerp(transform.localPosition,hedef1.localPosition,lerpvalue);
        Vector3 b = Vector3.Lerp(hedef1.localPosition,hedef.localPosition,lerpvalue);
        pos = Vector3.Lerp(a,b,lerpvalue);*/
    }
    void Deactive()
    {
        GameManager.instance.UpdateGoldUI();
        gameObject.SetActive(false);
    }
    
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 180);
        Vector3 a = Vector3.Lerp(p, hedef1.localPosition, lerpvalue);
        Vector3 b = Vector3.Lerp(hedef1.localPosition, hedef.localPosition, lerpvalue);
        pos = Vector3.Lerp(a, b, lerpvalue);
        transform.localPosition = pos;
        lerpvalue += Time.deltaTime;
        if (lerpvalue >= 1)
            Deactive();
    }
    private void OnDisable()
    {
        transform.localPosition = p;
        transform.localScale = Vector3.zero;
        lerpvalue = 0;
    }
}

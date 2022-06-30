using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class Mover : MonoBehaviour
{
    Vector2 startPos, currentPos, endPos;
    bool canMove;
    [SerializeField] float swipeRange, tapRange;
    Vector3 moveDir;
    Animator animator;
    [SerializeField] CinemachineVirtualCamera vCam;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Slide();
        transform.position += moveDir * Time.deltaTime *10;
        Quaternion look = Quaternion.LookRotation(moveDir);
        transform.rotation = Quaternion.Slerp(transform.rotation, look, 10f * Time.deltaTime);
        if (moveDir.magnitude > .9f)
            animator.SetBool("runn", true);
        if (transform.position.y <= -2)
            GameManager.instance.failMoment?.Invoke();
    }
    void Slide()
    {
        if (Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startPos = Input.GetTouch(0).position;

        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPos = Input.GetTouch(0).position;
            Vector2 dist = currentPos - startPos;

            if (canMove)
            {
                if (dist.x < -swipeRange)
                {
                    moveDir = Vector3.left;
                    canMove = false;
                    return;
                }
                if (dist.x > swipeRange)
                {
                    moveDir = Vector3.right;
                    canMove=false;
                    return;
                }
                if (dist.y < -swipeRange)
                {
                    moveDir = Vector3.back;
                    canMove = false;
                    return;
                }
                if (dist.y > swipeRange)
                {
                    moveDir = Vector3.forward;
                    canMove = false;
                    return;
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            GameManager.instance.failMoment?.Invoke();
        }
        else if (collision.gameObject.CompareTag("Final"))
        {
            GameManager.instance.finalMoment?.Invoke();
               
            
        } 
        else
        {
            collision.transform.DOShakeScale(0.5f, 0.7f);
            animator.SetTrigger("idle");
            canMove = true;
        }
        moveDir = Vector3.zero;
        animator.SetBool("runn", false);
    }
}

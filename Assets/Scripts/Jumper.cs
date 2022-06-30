using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Jumper : MonoBehaviour
{
    [SerializeField] Direction direction;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Animator>().SetBool("runn", false);
            other.GetComponent<Animator>().SetTrigger("jump");
            switch (direction)
            {
                case Direction.Right:
                    Jump(other.transform, Vector3.right);
                    break;
                case Direction.Left:
                    Jump(other.transform, Vector3.left);
                    break;
                case Direction.Up:
                    Jump(other.transform, Vector3.forward);
                    break;
                case Direction.Down:
                    Jump(other.transform, Vector3.back);
                    break;
                default:
                    break;
            }
        }
    }
    void Jump(Transform player,Vector3 dir)
    {
        GameManager.instance.astroidRotation.Move(transform.parent.position, 0.5f);
        player.DOJump(transform.parent.position + dir * 20, 10,1, 1.5f);
        transform.parent.DOShakePosition(.5f, 1);
        transform.parent.DOShakeScale(.5f, 1);
        Destroy(transform.parent.gameObject, 0.5f);
    }
}
public enum Direction
{
    Right,
    Left,
    Up,
    Down
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollwer : MonoBehaviour
{
    Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, 0, player.position.z);
    }
}

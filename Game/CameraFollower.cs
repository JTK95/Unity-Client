using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    Transform player;
    Vector3 offset;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - player.position;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,
            player.position + offset,
            Time.deltaTime * 3f);
    }
}

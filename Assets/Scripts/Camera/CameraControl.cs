using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float zOffset, yOffset;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void LateUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        transform.position = new Vector3(player.position.x, player.position.y + yOffset, player.position.z + zOffset);
    }
}

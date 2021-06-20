using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcPlayerMovement : MonoBehaviour
{
    public float speed = 7f;
    private Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        rigid.velocity = new Vector3(h * speed / 1.3f, rigid.velocity.y, speed);
    }
}

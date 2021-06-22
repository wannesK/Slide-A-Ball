using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlayerControl : MonoBehaviour
{
    public float forwardSpeed = 8f;
    public float turnSpeed = 0.007f;


    private Touch touch;
    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    //private void FixedUpdate()
    //{
    //    MoveForward();
    //}
    private void Update()
    {
        CheckForTouch();
        MoveForward();
    }

    private void MoveForward()
    {
        //rigid.velocity = Vector3.forward * forwardSpeed;     
        rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, forwardSpeed);
    }

    private void CheckForTouch()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * turnSpeed,
                                                 rigid.velocity.y, rigid.velocity.z);
            }
        }
    }
}

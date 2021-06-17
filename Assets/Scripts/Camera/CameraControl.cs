using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{   
    public float followSpeed;
    public Vector3 offset;

    private Transform player;
    private bool gameStarted;
    void Start()
    {
        StartCoroutine(FindPlayer());
    }
    void FixedUpdate()
    {
        FollowPlayer();
    }
    private void FollowPlayer()
    {
        if (gameStarted)
        {
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed);

            transform.position = smoothedPosition;
        }
    }

    private IEnumerator FindPlayer()
    {
        yield return new WaitForSeconds(0.01f);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        gameStarted = true;
    }
}

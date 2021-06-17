using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int greenBallCount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GreenBall"))
        {
            EnlargePlayer();
            Destroy(other.gameObject);
            //effect
        }
        else if (other.CompareTag("RedBall"))
        {
            ShrinkPlayer();
            Destroy(other.gameObject);
            //effect
        }
    }

    private void EnlargePlayer()
    {
        transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
        GreenBallCount();
    }
    private void ShrinkPlayer()
    {
        transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
        DecreaseGreenBall();
    }

    private void GreenBallCount()
    {
        greenBallCount++;
    }
    private void DecreaseGreenBall()
    {
        greenBallCount--;
    }
}

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
            
        }
        else if (other.CompareTag("RedBall"))
        {
            ShrinkPlayer();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("GroundTrap"))
        {
            GroundTrapDamage();
        }
    }

    private void EnlargePlayer()
    {
        transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
        //effect
        GreenBallCount();
    }
    private void ShrinkPlayer()
    {
        transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
        //effect
        //speed --
        DecreaseGreenBall();
    }
    private void GroundTrapDamage()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        //effect
        greenBallCount -= 2;
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

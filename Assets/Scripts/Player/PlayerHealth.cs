using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
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
        else if (other.CompareTag("Trap"))
        {
            TrapDamage();
        }
        else if (other.CompareTag("WallBarrier"))
        {
            TrapDamage();
            Destroy(other.gameObject);
            //Wall explotion effect
        }
        else if (other.CompareTag("RotatingTrap"))
        {
            gameManager.StopFunctions();
            Destroy(gameObject);
            //dead effect
            //restart level UI

        }
    }

    private void EnlargePlayer()
    {
        transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
        //effect
        gameManager.IncreaseGreenBall(1);
    }
    private void ShrinkPlayer()
    {
        transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
        //effect
        //speed --
        gameManager.DecreaseGreenBall(1);
    }
    private void TrapDamage()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        //effect
        gameManager.DecreaseGreenBall(2);
    }

}

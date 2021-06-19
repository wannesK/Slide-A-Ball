using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBall : MonoBehaviour
{
    public int bossHealt;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.StopFunctions();

            other.gameObject.GetComponent<PcPlayerMovement>().enabled = false;
            other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

            if (gameManager.greenBall > bossHealt)
            {                
                Destroy(gameObject);
                //effect
                //next level UI
            }
            else
            {
                Destroy(other.gameObject);
                //effect
                //restart level UI
            }

        }
    }

}

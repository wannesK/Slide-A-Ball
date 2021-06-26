using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float growthRate = 0.05f;

    private GameManager gameManager;
    private EffectController effect;
    private PcPlayerMovement movement;
    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        effect = GameObject.FindGameObjectWithTag("GameManager").GetComponent<EffectController>();

        movement = GetComponent<PcPlayerMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GreenBall"))
        {
            EnlargePlayer();
            effect.GreenBallEffect(other.transform);

            Destroy(other.gameObject);
            
        }
        else if (other.CompareTag("RedBall"))
        {
            ShrinkPlayer();
            effect.RedBallEffect(other.transform);

            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Trap"))
        {
            TrapDamage();
        }
        else if (other.CompareTag("WallBarrier"))
        {
            TrapDamage();

            effect.WallBreakEffect(other.gameObject.transform.GetChild(0));

            Destroy(other.gameObject);
        }
        else if (other.CompareTag("RotatingTrap"))
        {
            gameManager.StopFunctions();

            effect.PlayerDeathEffect(transform);

            Destroy(gameObject);

            gameManager.TriggerDeathPanel();

        }
    }

    private void EnlargePlayer()
    {
        transform.localScale += new Vector3(growthRate, growthRate, growthRate);

        gameManager.IncreaseGreenBall(1);
    }
    private void ShrinkPlayer()
    {
        transform.localScale -= new Vector3(growthRate, growthRate, growthRate);

        SlowDownPlayer();

        gameManager.DecreaseGreenBall(1);
    }
    private void TrapDamage()
    {
        transform.localScale -= new Vector3(growthRate * 2, growthRate * 2, growthRate * 2);

        SlowDownPlayer();

        gameManager.DecreaseGreenBall(2);
    }

    private void SlowDownPlayer()
    {
        effect.ShakeTheCamera();

        movement.speed /= 1.6f;
        StartCoroutine("GiveBackPLayerSpeed");
    }
    private IEnumerator GiveBackPLayerSpeed()
    {
        yield return new WaitForSeconds(0.3f);
        movement.speed *= 1.6f;
    }
}

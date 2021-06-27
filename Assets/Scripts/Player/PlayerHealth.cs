using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float growthRate = 0.05f;

    private GameManager gameManager;
    private EffectController effect;
    private PcPlayerMovement movement;
    private MobilePlayerControl playerControl;
    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        effect = GameObject.FindGameObjectWithTag("GameManager").GetComponent<EffectController>();

        movement = GetComponent<PcPlayerMovement>();
        playerControl = GetComponent<MobilePlayerControl>();
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
            PlayerIsDeath();
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
        
        gameManager.DecreaseGreenBall(1);

        SlowDownPlayer();        
    }
    private void TrapDamage()
    {
        transform.localScale -= new Vector3(growthRate * 2, growthRate * 2, growthRate * 2);

        gameManager.DecreaseGreenBall(2);

        SlowDownPlayer();
    }

    private void SlowDownPlayer()
    {
        effect.ShakeTheCamera();

        if (gameManager.greenBall < -2)
        {
            PlayerIsDeath();
        }

        playerControl.forwardSpeed /= 1.6f;
        movement.speed /= 1.6f;
        StartCoroutine("GiveBackPLayerSpeed");
    }
    private IEnumerator GiveBackPLayerSpeed()
    {
        yield return new WaitForSeconds(0.35f);
        playerControl.forwardSpeed *= 1.6f;
        movement.speed *= 1.6f;
    }

    public void PlayerIsDeath() 
    {
        gameManager.StopFunctions();

        effect.PlayerDeathEffect(transform);

        Destroy(gameObject);

        gameManager.TriggerDeathPanel();
    }
}

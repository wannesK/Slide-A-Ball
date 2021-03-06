using UnityEngine;

public class BossBall : MonoBehaviour
{
    public int bossHealt;

    private GameManager gameManager;
    private EffectController effect;
    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        effect = GameObject.FindGameObjectWithTag("GameManager").GetComponent<EffectController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.StopFunctions();

            other.gameObject.GetComponent<PcPlayerMovement>().enabled = false;
            other.gameObject.GetComponent<MobilePlayerControl>().enabled = false;
            //other.gameObject.GetComponent<PlayerHealth>().enabled = false;

            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;


            if (gameManager.greenBall > bossHealt)
            {                
                Destroy(gameObject);

                effect.BossDeathEffect(transform);

                gameManager.TriggerLevelCompleted();
            }
            else
            {
                Destroy(other.gameObject);

                effect.PlayerDeathEffect(other.transform);

                gameManager.TriggerDeathPanel();
            }

        }
    }

}

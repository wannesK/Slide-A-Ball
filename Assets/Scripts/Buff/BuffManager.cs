using System.Collections;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    private PcPlayerMovement movement;
    private MobilePlayerControl mobilePlayerControl;
    private EffectController effect;
    private void Start()
    {
        effect = GameObject.FindGameObjectWithTag("GameManager").GetComponent<EffectController>();

        StartCoroutine("FindPlayer");
    }
    private IEnumerator FindPlayer()
    {
        yield return new WaitForSeconds(1f);

        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PcPlayerMovement>();
        mobilePlayerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<MobilePlayerControl>();
    }
    public void BoltBuff()
    {
        effect.BoltEffect(movement.gameObject.transform);

        mobilePlayerControl.forwardSpeed *= 1.5f;
        movement.speed *= 1.5f;

        StartCoroutine("Debuff");
    }
    private IEnumerator Debuff()
    {
        yield return new WaitForSeconds(3f);
        mobilePlayerControl.forwardSpeed /= 1.5f;
        movement.speed /= 1.5f;
    }
}

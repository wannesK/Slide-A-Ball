using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    private PcPlayerMovement movement;
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
    }
    public void BoltBuff()
    {
        effect.BoltEffect(movement.gameObject.transform);

        movement.speed *= 1.5f;

        StartCoroutine("Debuff");
    }
    private IEnumerator Debuff()
    {
        yield return new WaitForSeconds(3f);
        movement.speed /= 1.5f;
    }
}

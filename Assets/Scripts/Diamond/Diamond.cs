using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{    
    public int minDiaValue, maxDiaValue;

    private DiamondsControl control;
    private EffectController effect;
    private void Start()
    {
        control = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DiamondsControl>();
        effect = GameObject.FindGameObjectWithTag("GameManager").GetComponent<EffectController>();        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {            
            int diamondValue = Random.Range(minDiaValue, maxDiaValue);

            control.IncreaseDiamond(diamondValue);

            effect.FloatingText(transform, $"+{diamondValue}");

            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{    
    public int minDiaValue, maxDiaValue;

    public DiamondsControl control;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int diamondValue = Random.Range(minDiaValue, maxDiaValue);

            control.IncreaseDiamond(diamondValue);
            Destroy(gameObject);
            Debug.Log(diamondValue);
            //effect

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public DiamondsControl control;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            control.IncreaseDiamond();
            Destroy(gameObject);
            //effect

        }
    }
}

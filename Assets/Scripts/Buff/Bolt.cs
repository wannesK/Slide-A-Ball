using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    private BuffManager manager;
    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<BuffManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.BoltBuff();
            
            Destroy(gameObject);
        }
    }
}

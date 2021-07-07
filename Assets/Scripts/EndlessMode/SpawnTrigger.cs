using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    private RoadSpawnManager manager;

    private float speedLimit = 7;
    private void Start()
    {
        manager = GameObject.Find("RoadSpawnManager").GetComponent<RoadSpawnManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.SpawnRoad();
            if (speedLimit <= 11f)
            {
                speedLimit += .25f;

                other.GetComponent<MobilePlayerControl>().forwardSpeed += .25f;
                other.GetComponent<PcPlayerMovement>().speed += .25f;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.DestroyRoad();            
        }
    }
}

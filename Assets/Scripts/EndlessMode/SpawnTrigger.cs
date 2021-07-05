using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    private RoadSpawnManager manager;
    private void Start()
    {
        manager = GameObject.Find("RoadSpawnManager").GetComponent<RoadSpawnManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.SpawnRoad();
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

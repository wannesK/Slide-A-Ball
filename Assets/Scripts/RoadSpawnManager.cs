using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawnManager : MonoBehaviour
{
    public float zAxisSpawnPoint;

    private Vector3 spawnHolder = new Vector3(0f, 0f, 0f);

    public GameObject[] roads;

    private void Start()
    {
        StartingRoadSpawner();              
    }

    private void StartingRoadSpawner()
    {
        RandomNumberGenerator(0, 11);

        for (int i = 0; i < 3; i++)
        {
            Instantiate(roads[i], spawnHolder, Quaternion.identity);

            spawnHolder.z += zAxisSpawnPoint;

            RandomNumberGenerator(0, 11);
        }
    }

    private int RandomNumberGenerator(int number , int secondNumber)
    {
        int randomNumber = Random.Range(number, secondNumber);

        return randomNumber;
    }


    
}

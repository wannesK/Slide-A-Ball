using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawnManager : MonoBehaviour
{
    public float zAxisSpawnPoint;

    public GameObject[] roads;
    public List<GameObject> roadHolder;

    private Vector3 spawnPosHolder = new Vector3(0f, 0f, 0f);
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnRoad();
        }            
    }

    private int RandomNumberGenerator(int min , int max)
    {
        int randomNumber = Random.Range(min, max);

        return randomNumber;
    }

    public void SpawnRoad()
    {
        var r = Instantiate(roads[RandomNumberGenerator(0, 28)], spawnPosHolder, Quaternion.identity);

        roadHolder.Add(r);

        spawnPosHolder.z += zAxisSpawnPoint;
    }

    public void DestroyRoad()
    {
        Destroy(roadHolder[0]);
        roadHolder.RemoveAt(0);
    }
}

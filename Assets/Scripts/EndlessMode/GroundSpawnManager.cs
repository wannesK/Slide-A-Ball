using System.Collections.Generic;
using UnityEngine;

public class GroundSpawnManager : MonoBehaviour
{
    public float zAxisSpawnPoint;

    public GameObject[] roads;
    public List<GameObject> roadHolder;

    private Vector3 spawnPosHolder = new Vector3(0f, 0f, 0f);

    private int spawnedRoad = 3;
    private int destroyedRoad = 0;

    private int lastRandomNumber = 50;

    #region Singleton
    public static GroundSpawnManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    private void Start()
    {
        GenerateRoad();
    }

    private int RandomNumberGenerator(int min , int max)
    {
        int randomNumber = Random.Range(min, max);

        if (randomNumber == lastRandomNumber)
        {
            randomNumber = Random.Range(min, max);
            Debug.Log(randomNumber);
            return randomNumber;
        }

        lastRandomNumber = randomNumber;
        return randomNumber;
    }

    public void GenerateRoad()
    {
        for (int i = 0; i < roads.Length; i++)
        {
            GameObject road = Instantiate(roads[RandomNumberGenerator(0, roads.Length)], spawnPosHolder, Quaternion.identity);

            roadHolder.Add(road);

            spawnPosHolder.z += zAxisSpawnPoint;

            if (i > 2)
            {
                road.SetActive(false);
            }
        }        
    }
    public void SpawnRoad()
    {
        roadHolder[spawnedRoad].SetActive(true);

        spawnedRoad++;       
    }
    public void DestroyRoad()
    {
        roadHolder[destroyedRoad].SetActive(false);

        SetTheTransform();

        destroyedRoad++;

        IsRoadOver();
    }
    private void SetTheTransform()
    {
        roadHolder[destroyedRoad].gameObject.transform.position = spawnPosHolder;

        spawnPosHolder.z += zAxisSpawnPoint;
    }
    private void IsRoadOver()
    {
        if (spawnedRoad >= roads.Length)
        {
            spawnedRoad = 0;
        }
        else if (destroyedRoad >= roads.Length)
        {
            destroyedRoad = 0;
        }
    }
}

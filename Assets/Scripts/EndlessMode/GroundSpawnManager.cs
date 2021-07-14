using System.Collections.Generic;
using UnityEngine;

public class GroundSpawnManager : MonoBehaviour
{
    public float zAxisSpawnPoint;

    public List<GameObject> roadPrefebs;
    public List<GameObject> roadObecjects;

    private Vector3 spawnPosHolder = new Vector3(0f, 0f, 0f);

    private int spawnedRoad = 3;
    private int destroyedRoad = 0;

    private int lastRandomNumber;

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

        lastRandomNumber = randomNumber;
        return randomNumber;
    }

    public void GenerateRoad()
    {
        int total = roadPrefebs.Count;

        for (int i = 0; i < total; i++)
        {
            GameObject road = Instantiate(roadPrefebs[RandomNumberGenerator(0, roadPrefebs.Count)], spawnPosHolder, Quaternion.identity);

            roadObecjects.Add(road);

            spawnPosHolder.z += zAxisSpawnPoint;

            if (i > 2)
            {
                road.SetActive(false);
            }
            roadPrefebs.RemoveAt(lastRandomNumber);
        }        
    }
    public void SpawnRoad()
    {
        roadObecjects[spawnedRoad].SetActive(true);

        spawnedRoad++;       
    }
    public void DestroyRoad()
    {
        roadObecjects[destroyedRoad].SetActive(false);

        SetTheTransform();

        destroyedRoad++;

        IsRoadOver();
    }
    private void SetTheTransform()
    {
        roadObecjects[destroyedRoad].gameObject.transform.position = spawnPosHolder;

        spawnPosHolder.z += zAxisSpawnPoint;
    }
    private void IsRoadOver()
    {
        if (spawnedRoad >= roadObecjects.Count)
        {
            spawnedRoad = 0;
        }
        else if (destroyedRoad >= roadObecjects.Count)
        {
            destroyedRoad = 0;
        }
    }
}

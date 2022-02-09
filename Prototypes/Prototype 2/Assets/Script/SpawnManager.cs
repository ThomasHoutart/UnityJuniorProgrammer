using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnRangeZBot = -1;
    private float spawnRangeZTop = 16;
    private float spawnPosX = 30;
    private float spawnPosZ = 20;
    
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    
    private Quaternion prefabRotationTop = Quaternion.Euler(0, 180, 0);
    private Quaternion prefabRotationLeft = Quaternion.Euler(0, 90, 0);
    private Quaternion prefabRotationRight = Quaternion.Euler(0, 270, 0);
    private Quaternion[] prefabRotationList;

    private void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        prefabRotationList = new[] {prefabRotationTop, prefabRotationLeft, prefabRotationRight};
    }

    void SpawnRandomAnimal()
    {
        Vector3 spawnPosXTop = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Vector3 spawnPosZLeft = new Vector3(-spawnPosX, 0, Random.Range(spawnRangeZBot, spawnRangeZTop));
        Vector3 spawnPosZRight = new Vector3(spawnPosX, 0, Random.Range(spawnRangeZBot, spawnRangeZTop));
        Vector3[] spawnPoints = new[] {spawnPosXTop, spawnPosZLeft, spawnPosZRight};

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Instantiate(animalPrefabs[animalIndex], spawnPoints[i], prefabRotationList[i]);
        }
    }
}

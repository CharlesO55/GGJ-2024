using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject carPrefab;
    [SerializeField] private GameObject fastCarPrefab;
    [SerializeField] private Road[] roads;

    private float timer;

    private void Start()
    {
        InitializeTimer();
    }

    private void Update()
    {

        if (timer < 0)
        {
            foreach (Road road in roads)
            {
                float rng = Random.Range(0f, 1f);
                if (rng > 0.8f)
                {
                    GameObject spawnedFastCar = Instantiate(fastCarPrefab, road.carSpawnerPoints[Random.Range(0,road.carSpawnerPoints.Length-1)].position, quaternion.identity);
                }
                else
                {
                    GameObject spawnedCar = Instantiate(carPrefab, road.carSpawnerPoints[Random.Range(0,road.carSpawnerPoints.Length-1)].position, quaternion.identity);
                }
            }
            
            InitializeTimer();
        }
        else
        {
            timer -= Time.deltaTime;
        }
        
    }

    private void InitializeTimer()
    {
        timer = Random.Range(1.5f, 2f);
    }
    
    
    [Serializable]
    private class Road
    {
        [HideInInspector] public string name = "Road";
        public Transform[] carSpawnerPoints;
    }

}

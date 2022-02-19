using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;

    [Header("Spawning")]

    [SerializeField] Transform[] obstacleSpawnPoints;

    [SerializeField] float timeToSpawn;
    [SerializeField] float minTimeToSpawn;
    [SerializeField] float setTimeToSpawn;

    [Header("Speed")]

    [SerializeField] float obstacleSpeed;
    [SerializeField] float obstacleSpeedCap;

    int obstaclesToSpawn = 1;
    float duration;

    void Start()
    {
        timeToSpawn = setTimeToSpawn;
    }

    void Update()
    {
        if (duration > 15)
        {
            obstaclesToSpawn = 2;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (timeToSpawn > 0)
        {
            timeToSpawn -= Time.deltaTime;
        }
        else
        {
            timeToSpawn = setTimeToSpawn;
            SpawnObstacle();
        }

        duration += Time.deltaTime;
    }

    void SpawnObstacle()
    {
        for (int i = 0; i < obstaclesToSpawn; i++)
        {
            GameObject go = Instantiate(obstaclePrefab, obstacleSpawnPoints[Random.Range(0, 3)].position, Quaternion.identity, this.transform);
            go.GetComponent<SwimmingObstacle>().SetStats(obstacleSpeed);
        }
    }
}

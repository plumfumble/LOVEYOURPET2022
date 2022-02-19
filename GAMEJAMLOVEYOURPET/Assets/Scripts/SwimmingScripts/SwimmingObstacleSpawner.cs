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
    [SerializeField] List<float> speedUpPoints;
    [SerializeField] List<float> setTimeSpawnPoints;

    [Header("Speed")]

    [SerializeField] float obstacleSpeed;
    [SerializeField] float obstacleSpeedCap;
    [SerializeField] List<float> obstacleSpeedPoints;

    int obstaclesToSpawn = 1;

    float duration;
    int speedUpIndex;

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
        for (int i = 0; i < speedUpPoints.Count; i++)
        {
            if (duration > speedUpPoints[i])
            {
                speedUpIndex = i;
            }
            else
            {
                break;
            }
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
            timeToSpawn = setTimeSpawnPoints[speedUpIndex];
            SpawnObstacle();
        }

        duration += Time.deltaTime;
    }

    void SpawnObstacle()
    {
        for (int i = 0; i < obstaclesToSpawn; i++)
        {
            GameObject go = Instantiate(obstaclePrefab, obstacleSpawnPoints[Random.Range(0, 3)].position, Quaternion.identity, this.transform);
            go.GetComponent<SwimmingObstacle>().SetStats(obstacleSpeedPoints[speedUpIndex]);
        }
    }
}

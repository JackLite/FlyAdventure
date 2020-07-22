using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    public Transform line1;
    public Transform line2;
    public Transform line3;

    public LevelData levelData;

    private Obstacle[] pool;
    private float patternTimer;
    private float obstacleTimer;
    private int patternIndex;
    private int obstacleIndex;
    private ObstaclePatternData patternData;
    private ObstacleDataContainer obstacleContainer;

    private enum SpawnerState
    {
        waitingPattern,
        createPattern,
        waitingObstacle,
        createObstacle
    }

    private SpawnerState state = SpawnerState.createPattern;

    private void Awake()
    {
        FillPool();
    }

    private void FillPool()
    {
        pool = new Obstacle[20];
        for (var i = 0; i < pool.Length; i++)
        {
            var newObstacle = Instantiate(obstaclePrefab);
            newObstacle.SetActive(false);
            pool[i] = newObstacle.GetComponent<Obstacle>();
        }
    }

    private void Update()
    {
        if (state == SpawnerState.createPattern)
        {
            patternData = GetNextPattern();
            obstacleContainer = patternData.obstaclesContainers[0];
            state = SpawnerState.waitingPattern;
        }

        if (state == SpawnerState.waitingPattern)
        {
            UpdatePatternTimer();
        }

        if (state == SpawnerState.waitingObstacle)
        {
            UpdateObstacleTimer();
        }

        if (state == SpawnerState.createObstacle)
        {
            foreach (var data in obstacleContainer.obstacles)
                CreateObstacle(data);

            obstacleIndex++;

            if (obstacleIndex >= patternData.obstaclesContainers.Length)
            {
                obstacleIndex = 0;
                state = SpawnerState.createPattern;
            }
            else
            {
                obstacleContainer = patternData.obstaclesContainers[obstacleIndex];
                state = SpawnerState.waitingObstacle;
            }
        }
    }

    private ObstacleDataContainer GetNextObstacleContainer(ObstaclePatternData patternData)
    {
        var container = patternData.obstaclesContainers[obstacleIndex++];
        return container;
    }

    private void UpdatePatternTimer()
    {
        patternTimer += Time.deltaTime;
        if (patternTimer < patternData.delay) return;
        patternTimer = 0;
        state = SpawnerState.waitingObstacle;
    }

    private void UpdateObstacleTimer()
    {
        obstacleTimer += Time.deltaTime;
        if (obstacleTimer < obstacleContainer.delay) return;
        obstacleTimer = 0;
        state = SpawnerState.createObstacle;
    }

    private void CreateObstacle(ObstacleData obstacleData)
    {
        foreach (var obstacle in pool)
        {
            if (obstacle.gameObject.activeSelf) continue;

            obstacle.data = obstacleData;
            obstacle.transform.position = GetSpawnPos(obstacle.data);
            obstacle.gameObject.SetActive(true);
            break;
        }
    }

    private Vector3 GetSpawnPos(ObstacleData data)
    {
        switch (data.line)
        {
            case 1:
                return line1.position;
            case 2:
                return line2.position;
            case 3:
                return line3.position;
        }
        return line3.position;
    }

    private ObstaclePatternData GetNextPattern()
    {
        if (patternIndex >= levelData.obstaclePatterns.Length) patternIndex = 0;
        return levelData.obstaclePatterns[patternIndex++];
    }

    private ObstacleData GetNextObstacle()
    {
        if(patternData == null)
        {
            patternData = GetNextPattern();
            obstacleIndex = 0;
        }
        if(obstacleIndex >= patternData.obstaclesContainers.Length)
        {
            patternData = GetNextPattern();
            obstacleIndex = 0;
        }
        return patternData.obstaclesContainers[obstacleIndex++].obstacles[0];
    }
}

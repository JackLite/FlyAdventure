using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObstaclePattern", menuName = "Obstacles/Obstacle pattern")]
public class ObstaclePatternData : ScriptableObject
{
    public float delay = 3f;
    public ObstacleDataContainer[] obstaclesContainers;
}

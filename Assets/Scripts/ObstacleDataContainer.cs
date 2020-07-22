using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObstaclePattern", menuName = "Obstacles/ObstacleContainer")]
public class ObstacleDataContainer : ScriptableObject
{
    public float delay = 1f;
    public ObstacleData[] obstacles;
}

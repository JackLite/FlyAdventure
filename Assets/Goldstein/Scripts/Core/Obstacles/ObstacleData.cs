using System;
using UnityEngine;

[Serializable]
public class ObstacleData
{
    [Range(1, 5)]
    public int line = 1;
    public float speed = 10;
    public ObstacleDirection direction = ObstacleDirection.left;
}

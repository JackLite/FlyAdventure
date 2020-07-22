using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Levels/Level data")]
public class LevelData : ScriptableObject
{
    public ObstaclePatternData[] obstaclePatterns;
}

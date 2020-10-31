using UnityEngine;

namespace Goldstein.Core.Obstacles
{
    [CreateAssetMenu(menuName = "Settings/ObstacleSpawn", fileName = "ObstacleSpawnSettings", order = 0)]
    public class ObstacleSpawnSettings : ScriptableObject
    {
        [Tooltip("Начальная позиция препятствия по оси Z")]
        public float zPosition;

        public float spawnFrequency = 1;
    }
}
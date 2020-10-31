using Goldstein.Core.Lines;
using Goldstein.Scripts.Utilities;
using Leopotam.Ecs;
using UnityEngine;
using Random = System.Random;

namespace Goldstein.Core.Obstacles
{
    public class ObstacleCreator : IEcsRunSystem
    {
        private readonly GameObject _obstaclePrefab;
        private readonly EcsWorld _ecsWorld;
        private readonly Random _random = new Random();
        private readonly LineSettings _lineSettings;
        private readonly ObstacleSpawnSettings _obstacleSpawnSettings;

        private float _timeSinceLastSpawn;

        public ObstacleCreator(GameObject obstaclePrefab)
        {
            _obstaclePrefab = obstaclePrefab;
        }

        public void Run()
        {
            _timeSinceLastSpawn += Time.deltaTime;
            if (!(_timeSinceLastSpawn > _obstacleSpawnSettings.spawnFrequency)) return;
            
            Spawn();
            _timeSinceLastSpawn = 0;
        }

        private void Spawn()
        {
            var obstacle = Object.Instantiate(_obstaclePrefab);
            obstacle.transform.position = GetRandomSpawnPoint();
            var collisionProvider = obstacle.AddComponent<ObstacleCollisionProvider>();
            var isCollideGetter = new GetterTemplate<bool>();
            isCollideGetter.SetGetter(() => collisionProvider.IsCollideWithPlayer);
            var obstacleComponent = new ObstacleComponent
            {
                speed = 12,
                direction = _random.NextDouble() > .5f ? Vector3.left : Vector3.right,
                transform = obstacle.transform,
                isCollideWithPlayer = isCollideGetter
            };
            var entity = _ecsWorld.NewEntity();
            entity.Replace(obstacleComponent);
        }

        private Vector3 GetRandomSpawnPoint()
        {
            var position = _lineSettings.linesStart[_random.Next(0, _lineSettings.linesStart.Length)];
            return new Vector3(position.x, position.y, _obstacleSpawnSettings.zPosition);
        }
    }
}
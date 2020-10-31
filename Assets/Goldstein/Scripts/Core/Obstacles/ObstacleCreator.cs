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
        
        private float _frequency = 2f;
        private float _timeSinceLastSpawn;

        public ObstacleCreator(GameObject obstaclePrefab)
        {
            _obstaclePrefab = obstaclePrefab;
        }
        
        public void Run()
        {
            _timeSinceLastSpawn += Time.deltaTime;
            if (_timeSinceLastSpawn > _frequency)
            {
                Spawn();
                _timeSinceLastSpawn = 0;
            }
        }

        private void Spawn()
        {
            var obstacle = Object.Instantiate(_obstaclePrefab);
            var obstacleComponent = new ObstacleComponent()
            {
                speed = 20,
                direction = _random.NextDouble() > .5f ? Vector3.left : Vector3.right,
                transform = obstacle.transform
            };
            var entity = _ecsWorld.NewEntity();
            entity.Replace(obstacleComponent);
        }
    }
}
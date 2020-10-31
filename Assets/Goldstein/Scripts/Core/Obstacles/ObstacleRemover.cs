using Leopotam.Ecs;
using UnityEngine;

namespace Goldstein.Core.Obstacles
{
    public class ObstacleRemover : IEcsRunSystem, IEcsDestroySystem
    {
        private readonly EcsFilter<ObstacleComponent> _filter;
        private readonly EcsFilter<ObstacleComponent, ObstacleCollideTag> _collideFilter;
        private readonly EcsWorld _world;
        private const float LifeTime = 10f;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var obstacle = ref _filter.Get1(i);
                obstacle.lifeTime += Time.deltaTime;
                if (obstacle.lifeTime > LifeTime)
                {
                    DestroyObstacle(_filter.GetEntity(i));
                }
            }
        }

        public void Destroy()
        {
            foreach (var i in _filter)
            {
                DestroyObstacle(_filter.GetEntity(i));
            }
        }

        private void DestroyObstacle(EcsEntity entity)
        {
            Object.Destroy(entity.Get<ObstacleComponent>().transform.gameObject);
            entity.Destroy();
        }
    }
}
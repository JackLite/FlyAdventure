using Leopotam.Ecs;
using UnityEngine;

namespace Goldstein.Core.Obstacles
{
    public class ObstacleRemover : IEcsRunSystem
    {
        private readonly EcsFilter<ObstacleComponent> _filter;
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
                    Object.Destroy(obstacle.transform.gameObject);
                    _filter.GetEntity(i).Destroy();
                }
            }
        }
    }
}
using Leopotam.Ecs;
using UnityEngine;

namespace Goldstein.Core.Obstacles
{
    public class ObstacleMovementSystem : IEcsRunSystem
    {
        private EcsFilter<ObstacleComponent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var obstacle = ref _filter.Get1(i);
                
                obstacle.transform.position += obstacle.direction * obstacle.speed * Time.deltaTime;
            }
        }
    }
}
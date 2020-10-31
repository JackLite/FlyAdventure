using Leopotam.Ecs;
using UnityEngine;
using Logger = Goldstein.Scripts.Utilities.Logger;

namespace Goldstein.Core.Obstacles
{
    public class ObstacleCollideSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ObstacleComponent>.Exclude<ObstacleCollideTag> _filter;
        private readonly EcsWorld _ecsWorld;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var obstacle = ref _filter.Get1(i);
                if (obstacle.isCollideWithPlayer.Get())
                {
                    _filter.GetEntity(i).Replace(new ObstacleCollideTag());
                    _ecsWorld.NewEntity().Replace(new EndGameEvent());
                }
            }
        }
    }
}
using Leopotam.Ecs;
using UnityEngine;

namespace Goldstein.Core
{
    public class EndGameSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<EndGameEvent> _filter;
        private readonly GameObject _endGameWindow;

        public EndGameSystem(GameObject endGameWindow)
        {
            _endGameWindow = endGameWindow;
        }
        
        public void Run()
        {
            if (_filter.GetEntitiesCount() <= 0) return;
            
            _world.NewEntity().Replace(new PauseCoreEvent());
            _endGameWindow.SetActive(true);
        }
    }
}
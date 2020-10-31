using Leopotam.Ecs;
using UnityEngine;

namespace Goldstein.Core
{
    public class EndGameSystem : IEcsRunSystem
    {
        private readonly EcsFilter<EndGameEvent> _filter;
        private readonly GameObject _endGameWindow;

        public EndGameSystem(GameObject endGameWindow)
        {
            _endGameWindow = endGameWindow;
        }
        
        public void Run()
        {
            if (_filter.GetEntitiesCount() > 0)
            {
                Time.timeScale = 0;
                _endGameWindow.SetActive(true);
            }
        }
    }
}
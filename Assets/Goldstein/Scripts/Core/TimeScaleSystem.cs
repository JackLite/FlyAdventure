using Goldstein.Core.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace Goldstein.Core
{
    public class TimeScaleSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PauseCoreEvent> _filterPause;
        private readonly EcsFilter<ResumeCoreEvent> _filterUnPause;
        
        public void Run()
        {
            if (_filterPause.GetEntitiesCount() > 0)
                Time.timeScale = 0;

            if (_filterUnPause.GetEntitiesCount() > 0)
                Time.timeScale = 1;
        }
    }
}
using Goldstein.Core.CompositionRoot;
using Goldstein.Core.Events;
using Leopotam.Ecs;

namespace Goldstein.Core
{
    public class RestartSystem : IEcsRunSystem
    {
        private readonly EcsFilter<RestartEvent> _filter;
        private readonly CoreInstaller _coreInstaller;

        public RestartSystem(CoreInstaller installer)
        {
            _coreInstaller = installer;
        }
        
        public void Run()
        {
            if (_filter.GetEntitiesCount() <= 0) return;
            
            _coreInstaller.Restart();
        }
    }
}
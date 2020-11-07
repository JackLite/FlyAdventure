using Goldstein.Utilities.UiProviders;
using Leopotam.Ecs;

namespace Goldstein.Core
{
    public class EndGameSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<EndGameEvent> _filter;
        private readonly ScreenProvider _endGameWindow;

        public EndGameSystem(ScreenProvider endGameWindow)
        {
            _endGameWindow = endGameWindow;
        }
        
        public void Run()
        {
            if (_filter.GetEntitiesCount() <= 0) return;
            
            _world.NewEntity().Replace(new PauseCoreEvent());
            _endGameWindow.Enable();
        }

        public void Init()
        {
            _endGameWindow.Disable();
        }
    }
}
using Goldstein.Core.Events;
using Goldstein.Utilities.UiProviders;
using Leopotam.Ecs;

namespace Goldstein.Core.Proxies
{
    public class RestartProxy : IEcsInitSystem, IEcsDestroySystem
    {
        private readonly ButtonProvider _restartButton;
        private readonly EcsWorld _world;

        public RestartProxy(ButtonProvider restartButton)
        {
            _restartButton = restartButton;
        }
        
        public void Init()
        {
            _restartButton.OnButtonClick += CreateRestartEvent;
        }

        private void CreateRestartEvent()
        {
            _world.NewEntity().Replace(new RestartEvent());
        }

        public void Destroy()
        {
            _restartButton.OnButtonClick -= CreateRestartEvent;
        }
    }
}
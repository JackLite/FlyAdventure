using Goldstein.Scripts.Utilities;
using Goldstein.Utilities.UiProviders;
using Leopotam.Ecs;

namespace Goldstein.Core
{
    public class PauseSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private readonly EcsWorld _world;
        private readonly ButtonProvider _pauseButton;
        private bool _isPaused;

        public PauseSystem(ButtonProvider buttonProvider)
        {
            _pauseButton = buttonProvider;
        }

        public void Init()
        {
            _pauseButton.OnButtonClick += CreatePauseEvent;
        }

        private void CreatePauseEvent()
        {
            Logger.Log("Click!");
            if (_isPaused)
            {
                _isPaused = false;
                _world.NewEntity().Replace(new UnPauseCoreEvent());
            }
            else
            {
                _isPaused = true;
                _world.NewEntity().Replace(new PauseCoreEvent());
            }
        }

        public void Destroy()
        {
            _pauseButton.OnButtonClick -= CreatePauseEvent;
        }
    }
}
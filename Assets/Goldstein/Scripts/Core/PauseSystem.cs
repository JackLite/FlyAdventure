using Goldstein.Core.Events;
using Goldstein.Utilities.UiProviders;
using Leopotam.Ecs;

namespace Goldstein.Core
{
    public class PauseSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private readonly ButtonProvider _pauseButton;
        private readonly ButtonProvider _resumeButton;
        private readonly ScreenProvider _pauseScreen;
        private readonly EcsWorld _world;

        public PauseSystem(ButtonProvider pauseButton, ButtonProvider resumeButton, ScreenProvider pauseScreen)
        {
            _pauseButton = pauseButton;
            _resumeButton = resumeButton;
            _pauseScreen = pauseScreen;
        }

        public void Destroy()
        {
            _pauseButton.OnButtonClick -= CreatePauseEvent;
        }

        public void Init()
        {
            _pauseButton.OnButtonClick += CreatePauseEvent;
            _resumeButton.OnButtonClick += CreateResumeEvent;
        }

        private void CreatePauseEvent()
        {
            _world.NewEntity().Replace(new PauseCoreEvent());
            _pauseScreen.Enable();
        }

        private void CreateResumeEvent()
        {
            _world.NewEntity().Replace(new ResumeCoreEvent());
            _pauseScreen.Disable();
        }
    }
}
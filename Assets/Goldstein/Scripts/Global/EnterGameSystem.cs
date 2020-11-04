using Goldstein.Utilities.UiProviders;
using Leopotam.Ecs;

namespace Goldstein.Scripts.Global
{
    public sealed class EnterGameSystem : IEcsInitSystem
    {
        private readonly EcsWorld _ecsWorld;
        private readonly ButtonProvider _startGameButton;

        public EnterGameSystem(ButtonProvider startBtn)
        {
            _startGameButton = startBtn;
        }
        
        public void Init()
        {
            _startGameButton.OnButtonClick += CreateStartGameEvent;
        }

        private void CreateStartGameEvent()
        {
            _ecsWorld.NewEntity().Replace(new SceneLoadEvent {sceneName = "Game"});
        }
    }
}
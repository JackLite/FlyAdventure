using Goldstein.Core.CompositionRoot;
using Goldstein.Core.Events;
using Goldstein.Core.Proxies;
using Goldstein.Scripts.Utilities;
using Goldstein.Utilities.UiProviders;
using Leopotam.Ecs;
using UnityEngine;

namespace Goldstein.Core
{
    public sealed class CommonInstaller : AbstractSystemInstaller
    {
        [SerializeField] private ScreenProvider endGameWindow;
        [SerializeField] private ButtonProvider pauseButton;
        [SerializeField] private ButtonProvider resumeButton;
        [SerializeField] private ButtonProvider restartButton;

        [SerializeField] private ScreenProvider pauseScreen;
        
        [SerializeField] private CoreInstaller coreInstaller;
        public override void RegisterSystems(EcsWorld world, EcsSystems systems)
        {
            systems.Add(new PlayerInitSystem())
                .Add(new EndGameSystem(endGameWindow))
                .Add(new TimeScaleSystem())
                .Add(new PauseSystem(pauseButton, resumeButton, pauseScreen))
                .Add(new RestartSystem(coreInstaller))
                .Add(new RestartProxy(restartButton))
                .OneFrame<RestartEvent>()
                .OneFrame<PauseCoreEvent>()
                .OneFrame<ResumeCoreEvent>();
        }
    }
}
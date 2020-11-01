using Goldstein.Scripts.Utilities;
using Goldstein.Utilities.UiProviders;
using Leopotam.Ecs;
using UnityEngine;

namespace Goldstein.Core
{
    public sealed class CommonInstaller : AbstractSystemInstaller
    {
        [SerializeField] private GameObject endGameWindow;
        [SerializeField] private ButtonProvider pauseButton;
        
        public override void RegisterSystems(EcsWorld world, EcsSystems systems)
        {
            endGameWindow.SetActive(false);
            systems.Add(new PlayerInitSystem())
                .Add(new TimeScaleSystem())
                .Add(new PauseSystem(pauseButton))
                .Add(new EndGameSystem(endGameWindow))
                .OneFrame<PauseCoreEvent>()
                .OneFrame<UnPauseCoreEvent>();
        }
    }
}
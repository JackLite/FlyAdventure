using Goldstein.Scripts.Utilities;
using Goldstein.Utilities.UiProviders;
using Leopotam.Ecs;
using UnityEngine;

namespace Goldstein.Scripts.Global
{
    public sealed class MainMenuInstaller : AbstractSystemInstaller
    {
        [SerializeField] private ButtonProvider startGameButton;
        
        public override void RegisterSystems(EcsWorld world, EcsSystems ecsSystems)
        {
            ecsSystems.Add(new EnterGameSystem(startGameButton))
                .Add(new SceneLoadSystem())
                .OneFrame<SceneLoadEvent>();
        }
    }
}
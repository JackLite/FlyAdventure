using Goldstein.Scripts.Utilities;
using Leopotam.Ecs;
using UnityEngine;

namespace Goldstein.Core
{
    public sealed class CommonInstaller : AbstractSystemInstaller
    {
        [SerializeField] private GameObject endGameWindow;
        
        public override void RegisterSystems(EcsWorld world, EcsSystems systems)
        {
            endGameWindow.SetActive(false);
            systems.Add(new PlayerInitSystem())
                .Add(new EndGameSystem(endGameWindow));
        }
    }
}
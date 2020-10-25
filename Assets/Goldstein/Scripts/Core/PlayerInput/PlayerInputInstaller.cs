using Goldstein.Scripts.Utilities;
using Leopotam.Ecs;

namespace Goldstein.Core.PlayerInput
{
    public class PlayerInputInstaller : AbstractSystemInstaller
    {
        private EcsWorld _world;

        public override void RegisterSystems(EcsWorld world, EcsSystems systems)
        {
            systems.Add(new KeyboardInputSystem());/*
                .Add(new TouchscreenInputSystem())*/;
        }
    }
}
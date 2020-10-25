using Goldstein.Scripts.Utilities;
using Leopotam.Ecs;

namespace Goldstein.Core
{
    public sealed class CommonInstaller : AbstractSystemInstaller
    {
        public override void RegisterSystems(EcsWorld world, EcsSystems systems)
        {
            systems.Add(new PlayerInitSystem());
        }
    }
}
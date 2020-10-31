using Goldstein.Scripts.Utilities;
using Leopotam.Ecs;
using UnityEngine;

namespace Goldstein.Core.Obstacles
{
    public class ObstacleInstaller : AbstractSystemInstaller
    {
        [SerializeField] private GameObject obstaclePrefab;

        public override void RegisterSystems(EcsWorld world, EcsSystems ecsSystems)
        {
            ecsSystems.Add(new ObstacleMovementSystem())
                .Add(new ObstacleCreator(obstaclePrefab));
        }
    }
}
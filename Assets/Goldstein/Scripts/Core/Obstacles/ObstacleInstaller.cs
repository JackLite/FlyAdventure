using Goldstein.Core.Lines;
using Goldstein.Scripts.Utilities;
using Leopotam.Ecs;
using UnityEngine;

namespace Goldstein.Core.Obstacles
{
    public class ObstacleInstaller : AbstractSystemInstaller
    {
        [SerializeField] private GameObject obstaclePrefab;
        [SerializeField] private LineSettings lineSettings;
        [SerializeField] private ObstacleSpawnSettings obstacleSpawnSettings;

        public override void RegisterSystems(EcsWorld world, EcsSystems ecsSystems)
        {
            ecsSystems.Add(new ObstacleMovementSystem())
                .Add(new ObstacleCreator(obstaclePrefab))
                .Add(new ObstacleRemover())
                .Inject(lineSettings)
                .Inject(obstacleSpawnSettings);
        }
    }
}
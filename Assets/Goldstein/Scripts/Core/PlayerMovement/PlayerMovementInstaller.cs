using Goldstein.Scripts.Utilities;
using Leopotam.Ecs;
using UnityEngine;

namespace Goldstein.Core.PlayerMovement
{
    public class PlayerMovementInstaller : AbstractSystemInstaller
    {
        private EcsSystems _systems;

        [SerializeField] private PlayerMoveController leftPlayerMovementController;
        [SerializeField] private PlayerMoveController rightPlayerMovementController;

        [SerializeField] private PlayerPositionProvider leftPlayerPositionProvider;
        [SerializeField] private PlayerPositionProvider rightPlayerPositionProvider;

        [SerializeField] private MovementSettings movementSettings;

        public override void RegisterSystems(EcsWorld world, EcsSystems systems)
        {
            systems.Add(new PlayerMovementSystem(leftPlayerMovementController, rightPlayerMovementController))
                .Add(new PlayerPositionInfoSystem(leftPlayerPositionProvider, rightPlayerPositionProvider))
                .Inject(movementSettings);
        }
    }
}
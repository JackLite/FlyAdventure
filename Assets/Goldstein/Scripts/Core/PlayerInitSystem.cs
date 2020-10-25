using Goldstein.Core.PlayerInput;
using Goldstein.Core.PlayerMovement;
using Leopotam.Ecs;
using UnityEngine;

namespace Goldstein.Core
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorld _world;

        public void Init()
        {
            var leftPlayer = _world.NewEntity();
            leftPlayer.Get<LeftPlayerTag>();
            leftPlayer.Get<PlayerInputComponent>();
            leftPlayer.Get<PlayerPositionComponent>();

            var rightPlayer = _world.NewEntity();
            rightPlayer.Get<RightPlayerTag>();
            rightPlayer.Get<PlayerInputComponent>();
            rightPlayer.Get<PlayerPositionComponent>();
        }
    }
}
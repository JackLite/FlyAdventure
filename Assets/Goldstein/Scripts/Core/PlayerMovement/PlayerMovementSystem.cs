using Goldstein.Core.PlayerInput;
using Leopotam.Ecs;

namespace Goldstein.Core.PlayerMovement
{
    public class PlayerMovementSystem : IEcsPostDestroySystem, IEcsRunSystem
    {
        private readonly PlayerMoveController _leftPlayer;
        private readonly PlayerMoveController _rightPlayer;
        private readonly EcsWorld _world;
        private readonly MovementSettings _movementSettings;
        
        private EcsFilter<LeftPlayerTag, PlayerInputComponent> _leftPlayerFilter;
        private EcsFilter<RightPlayerTag, PlayerInputComponent> _rightPlayerFilter;

        public PlayerMovementSystem(PlayerMoveController leftPlayer, PlayerMoveController rightPlayer)
        {
            _leftPlayer = leftPlayer;
            _rightPlayer = rightPlayer;
        }

        public void Run()
        {
            ref var leftPlayer = ref _leftPlayerFilter.Get2(0);
            ref var rightPlayer = ref _rightPlayerFilter.Get2(0);
            _leftPlayer.MovePlayer(leftPlayer.value, _movementSettings.speed);
            _rightPlayer.MovePlayer(rightPlayer.value, _movementSettings.speed);
        }

        public void PostDestroy()
        {
            _leftPlayer.Reset();
            _rightPlayer.Reset();
        }
    }
}
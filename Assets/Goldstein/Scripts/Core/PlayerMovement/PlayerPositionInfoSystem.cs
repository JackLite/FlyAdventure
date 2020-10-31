using Leopotam.Ecs;

namespace Goldstein.Core.PlayerMovement
{
    public class PlayerPositionInfoSystem : IEcsRunSystem
    {
        private readonly PlayerPositionProvider _leftPlayerPositionProvider;
        private readonly PlayerPositionProvider _rightPlayerPositionProvider;
        private EcsWorld _world;
        private EcsFilter<LeftPlayerTag, PlayerPositionComponent> _leftPlayerFilter;
        private EcsFilter<RightPlayerTag, PlayerPositionComponent> _rightPlayerFilter;

        public PlayerPositionInfoSystem(PlayerPositionProvider leftPlayerPositionProvider,
            PlayerPositionProvider rightPlayerPositionProvider)
        {
            _leftPlayerPositionProvider = leftPlayerPositionProvider;
            _rightPlayerPositionProvider = rightPlayerPositionProvider;
        }

        public void Run()
        {
            UpdateLeftPlayerPos();
            UpdateRightPlayerPos();
        }

        private void UpdateLeftPlayerPos()
        {
            ref var position = ref _leftPlayerFilter.Get2(0);
            var realPosition = _leftPlayerPositionProvider.WorldPosition;
            position.x = realPosition.x;
            position.y = realPosition.y;
        }
        
        private void UpdateRightPlayerPos()
        {
            ref var position = ref _rightPlayerFilter.Get2(0);
            var realPosition = _rightPlayerPositionProvider.WorldPosition;
            position.x = realPosition.x;
            position.y = realPosition.y;
        }
    }
}
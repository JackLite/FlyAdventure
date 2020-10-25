using Leopotam.Ecs;

namespace Goldstein.Core.PlayerMovement
{
    public class PlayerPositionInfoSystem : IEcsRunSystem
    {
        private readonly PlayerPositionProvider _leftPlayerPositionProvider;
        private EcsWorld _world;
        private EcsFilter<LeftPlayerTag, PlayerPositionComponent> _leftPlayerFilter;

        public PlayerPositionInfoSystem(PlayerPositionProvider leftPlayerPositionProvider)
        {
            _leftPlayerPositionProvider = leftPlayerPositionProvider;
        }
        
        public void Run()
        {
            ref var position = ref _leftPlayerFilter.Get2(0);
            var realPosition = _leftPlayerPositionProvider.WorldPosition;
            position.x = realPosition.x;
            position.y = realPosition.y;
        }
    }
}
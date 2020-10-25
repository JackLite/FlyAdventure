using Goldstein.Core.PlayerMovement;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

namespace Goldstein.Core.PlayerInput
{
    public sealed class TouchscreenInputSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter<LeftPlayerTag, PlayerInputComponent, PlayerPositionComponent> _leftPlayerFilter;
        private EcsFilter<RightPlayerTag, PlayerInputComponent, PlayerPositionComponent> _rightPlayerFilter;
        private Camera _mainCamera;

        public void Run()
        {
            ref var leftPosition = ref _leftPlayerFilter.Get3(0);
            _leftPlayerFilter.Get2(0).value = GetLeftInput(leftPosition);
        }

        private float GetLeftInput(PlayerPositionComponent positionComponent)
        {
            foreach (var touch in Touch.activeTouches)
            {
                var worldTouchPos = _mainCamera.ScreenToWorldPoint(touch.screenPosition);
                return worldTouchPos.y > positionComponent.y ? 1f : -1f;
            }

            return 0f;
        }

        public void Init()
        {
            EnhancedTouchSupport.Enable();
#if UNITY_EDITOR
            TouchSimulation.Enable();
#endif
        }
    }
}
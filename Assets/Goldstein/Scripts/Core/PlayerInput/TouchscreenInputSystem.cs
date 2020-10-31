using Goldstein.Core.PlayerMovement;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

namespace Goldstein.Core.PlayerInput
{
    public sealed class TouchscreenInputSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter<LeftPlayerTag, PlayerInputComponent, PlayerPositionComponent> _leftPlayerFilter;
        private EcsFilter<RightPlayerTag, PlayerInputComponent, PlayerPositionComponent> _rightPlayerFilter;

        private readonly Camera _mainCamera;
        private readonly Camera _leftCamera;
        private readonly Camera _rightCamera;

        public TouchscreenInputSystem(Camera mainCam, Camera leftCam, Camera rightCam)
        {
            _mainCamera = mainCam;
            _leftCamera = leftCam;
            _rightCamera = rightCam;
        }
        
        public void Run()
        {
            ref var leftPosition = ref _leftPlayerFilter.Get3(0);
            ref var rightPosition = ref _rightPlayerFilter.Get3(0);
            _leftPlayerFilter.Get2(0).value = Mathf.Clamp(GetLeftInput(leftPosition), -1, 1);
            _rightPlayerFilter.Get2(0).value = Mathf.Clamp(GetRightInput(rightPosition), -1, 1);
        }

        private float GetLeftInput(PlayerPositionComponent positionComponent)
        {
            foreach (var touch in Touch.activeTouches)
            {
                var ray = _mainCamera.ScreenPointToRay(touch.screenPosition);
                var hits = new RaycastHit[1];
                Physics.RaycastNonAlloc(ray, hits);
                if (hits[0].collider == null || !hits[0].collider.TryGetComponent<LeftScreenTag>(out _)) continue;
                var worldTouchPos = _mainCamera.ScreenToWorldPoint(touch.screenPosition);
                return worldTouchPos.y + _leftCamera.transform.position.y - positionComponent.y;
            }

            return 0f;
        }

        private float GetRightInput(PlayerPositionComponent positionComponent)
        {
            foreach (var touch in Touch.activeTouches)
            {
                var ray = _mainCamera.ScreenPointToRay(touch.screenPosition);
                var hits = new RaycastHit[1];
                Physics.RaycastNonAlloc(ray, hits);
                if (hits[0].collider == null || !hits[0].collider.TryGetComponent<RightScreenTag>(out _)) continue;
                var worldTouchPos = _mainCamera.ScreenToWorldPoint(touch.screenPosition);
                return worldTouchPos.y + _rightCamera.transform.position.y - positionComponent.y;
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
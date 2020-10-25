using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Goldstein.Core.PlayerInput
{
    public class KeyboardInputSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private EcsFilter<LeftPlayerTag, PlayerInputComponent> _leftPlayerFilter;
        private EcsFilter<RightPlayerTag, PlayerInputComponent> _rightPlayerFilter;

        public void Run()
        {
            Debug.Log(_leftPlayerFilter.GetEntitiesCount());
            ref var leftPlayer = ref _leftPlayerFilter.Get2(0);
            leftPlayer.value = GetLeftInput();
            ref var rightPlayer = ref _rightPlayerFilter.Get2(0);
            rightPlayer.value = GetRightInput();
        }

        private float GetLeftInput()
        {
            var leftValue = 0f;
            if (Keyboard.current.wKey.isPressed)
                leftValue += 1;
            if (Keyboard.current.sKey.isPressed)
                leftValue -= 1;
            return leftValue;
        }

        private float GetRightInput()
        {
            var rightValue = 0f;
            if (Keyboard.current.upArrowKey.isPressed)
                rightValue += 1;
            if (Keyboard.current.downArrowKey.isPressed)
                rightValue -= 1;
            return rightValue;
        }
    }
}
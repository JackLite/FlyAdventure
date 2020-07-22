using Game.Level.Player;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

namespace Game.Level.Scripts
{
    class PlayerTouchInput : IPlayerInput
    {
        private readonly AvatarControl _avatarControl;
        private readonly Transform _playerTransform;
        private readonly Camera _mainCamera;

        public PlayerTouchInput(AvatarControl avatarControl, Transform playerTransform)
        {
            _avatarControl = avatarControl;
            _playerTransform = playerTransform;
            _mainCamera = Camera.main;
        }

        public int ReadInput()
        {
            if (!_avatarControl.IsControlled) return 0;
            return 0;
            /*var distance = Math.Abs(pointerPosition.y - _playerTransform.position.y);

            if (distance < 0.01f) return 0;

            if (pointerPosition.y > _playerTransform.position.y) return 1;
            else return -1;*/
        }
    }
}

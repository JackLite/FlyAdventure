using Assets.Game.Level.Scripts;
using Game.Level.Scripts;
using UnityEngine;


namespace Game.Level.Player
{
    public class PlayerAvatarController : MonoBehaviour
    {
        [SerializeField]
        private AvatarType _avatarType;

        [SerializeField]
        private float _speed;

        [SerializeField]
        private Transform _minPos;

        [SerializeField]
        private Transform _maxPos;

        [SerializeField]
        private AvatarControl _avatarControl;

        private IPlayerInput _playerInput;
        private Transform _transform;


        private void Awake()
        {
            _transform = GetComponent<Transform>();

            if (Application.platform == RuntimePlatform.Android
                || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                if (_avatarType == AvatarType.leftAvatar)
                    _playerInput = new PlayerTouchInput(_avatarControl, transform);
                else
                    _playerInput = new PlayerTouchInput(_avatarControl, transform);
            }
            else if (Application.platform == RuntimePlatform.WindowsEditor
                || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                if (_avatarType == AvatarType.leftAvatar)
                    _playerInput = new KeyboardWASDPlayerInput();
                else
                    _playerInput = new KeyboardArrowsPlayerInput();
            }
        }

        private void Update()
        {
            var yDelta = _speed * Time.deltaTime * _playerInput.ReadInput();
            var resultY = yDelta + _transform.position.y;
            resultY = Mathf.Clamp(resultY, _minPos.position.y, _maxPos.position.y);
            _transform.position = new Vector3(_transform.position.x, resultY, _transform.position.z);
        }

        private enum AvatarType
        {
            leftAvatar,
            rightAvatar
        }
    }
}
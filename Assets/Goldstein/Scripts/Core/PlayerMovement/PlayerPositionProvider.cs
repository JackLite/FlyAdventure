using UnityEngine;

namespace Goldstein.Core.PlayerMovement
{
    public class PlayerPositionProvider : MonoBehaviour
    {
        private Transform _transform;

        public Vector3 WorldPosition
        {
            get
            {
                if (_transform == null)
                    _transform = transform;
                return _transform.position;
            }
        }
    }
}
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;

namespace Game.Level.Scripts
{
    [RequireComponent(typeof(Image))]
    class AvatarControl : MonoBehaviour
    {
        public bool IsControlled { get; private set; }

        private void Awake()
        {
            IsControlled = false;
        }

        public void Test()
        {
            Debug.Log(123);
        }
    }
}

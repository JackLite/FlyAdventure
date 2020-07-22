using Game.Level.Scripts;
using UnityEngine.InputSystem;

namespace Assets.Game.Level.Scripts
{
    public class KeyboardWASDPlayerInput : IPlayerInput
    {
        public int ReadInput()
        {
            var w = Keyboard.current.wKey;
            var s = Keyboard.current.sKey;
            if (w.isPressed && s.isPressed) return 0;

            if (w.isPressed) return 1;
            if (s.isPressed) return -1;

            return 0;
        }
    }
}

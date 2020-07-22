using Game.Level.Scripts;
using UnityEngine.InputSystem;

namespace Assets.Game.Level.Scripts
{
    public class KeyboardArrowsPlayerInput : IPlayerInput
    {
        public int ReadInput()
        {
            var upArrow = Keyboard.current.upArrowKey;
            var downArrow = Keyboard.current.downArrowKey;
            if (upArrow.isPressed && downArrow.isPressed) return 0;

            if (upArrow.isPressed) return 1;
            if (downArrow.isPressed) return -1;

            return 0;
        }
    }
}

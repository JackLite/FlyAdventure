using UnityEngine;

namespace Game.Level.Scripts
{
    public interface IPlayerInput
    {
        /// <returns>Return vertical axis (up = 1, down = -1) </returns>
        int ReadInput();
    }
}

using UnityEngine;

namespace Goldstein.Core.PlayerMovement
{
    [CreateAssetMenu(menuName = "Settings/Movement", fileName = "MovementSettings", order = 0)]
    public class MovementSettings : ScriptableObject
    {
        public int speed;
    }
}
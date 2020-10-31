using UnityEngine;
using Logger = Goldstein.Scripts.Utilities.Logger;

namespace Goldstein.Core.PlayerMovement
{
    public class PlayerMoveController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D playerRigidBody;
        public void MovePlayer(float yDirection, float speed)
        {
            if (playerRigidBody == null)
            {
                Logger.LogError($"Не установлен rigidbody игрока на {name}");
                return;
            }
            var oldPos = playerRigidBody.position;
            playerRigidBody.MovePosition(new Vector2(oldPos.x, oldPos.y + yDirection * speed * Time.fixedDeltaTime));
        }
    }
}
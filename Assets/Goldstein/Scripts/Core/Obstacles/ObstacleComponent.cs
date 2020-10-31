using Goldstein.Scripts.Utilities;
using UnityEngine;

namespace Goldstein.Core.Obstacles
{
    public struct ObstacleComponent
    {
        public int speed;
        public Vector3 direction;
        public Transform transform;
        /// <summary>
        /// Сколько времени существует препятствие
        /// </summary>
        public float lifeTime;

        public GetterTemplate<bool> isCollideWithPlayer;
    }
}
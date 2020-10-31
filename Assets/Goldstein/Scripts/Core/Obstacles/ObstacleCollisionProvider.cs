using System;
using UnityEngine;

namespace Goldstein.Core.Obstacles
{
    public class ObstacleCollisionProvider : MonoBehaviour
    {
        public bool IsCollideWithPlayer { get; private set; }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player"))
                return;
            IsCollideWithPlayer = true;
        }
    }
}
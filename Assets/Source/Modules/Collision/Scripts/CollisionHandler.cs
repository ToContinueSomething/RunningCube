using System;
using UnityEngine;

namespace Collision.Source.Modules.Collision.Scripts
{
    public class CollisionHandler : MonoBehaviour
    {
        [SerializeField] private LayerMask _obstacleMask;
        [SerializeField] private LayerMask _finishMask;

        public event Action ObstacleCollided;
        public event Action FinishCollided;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == Mathf.Log(_obstacleMask.value, 2))
            {
                ObstacleCollided?.Invoke();
                return;
            }

            if (IsRightCollision(other))
            {
                ObstacleCollided?.Invoke();
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (IsRightCollision(collision))
            {
                ObstacleCollided?.Invoke();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == Mathf.Log(_finishMask.value, 2))
            {
                FinishCollided?.Invoke();
            }
        }

        private bool IsRightCollision(Collision2D collision)
        {
            foreach (var contact in collision.contacts)
            {
                if (contact.normal == -Vector2.right)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
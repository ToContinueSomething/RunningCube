using UnityEngine;

namespace Source.Modules.Respawner.Scripts
{
    public class ShipRespawner : MonoBehaviour
    {
        [SerializeField] private TrailRenderer _trailRenderer;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Transform _shipTransform;
        [SerializeField] private Transform _startPoint;

        public void Respawn()
        {
            _rigidbody.position = _startPoint.position;
            _shipTransform.rotation = Quaternion.identity;
            _rigidbody.velocity = Vector2.zero;
            _trailRenderer.Clear();
        }
    }
}

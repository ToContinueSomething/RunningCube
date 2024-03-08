using UnityEngine;

namespace Source.Modules.Respawner.Scripts
{
    public class CameraRespawner : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _startPoint;

        public void Respawn()
        {
            _camera.transform.position = _startPoint.position;
        }
    }
}
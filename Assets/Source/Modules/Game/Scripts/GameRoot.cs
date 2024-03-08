using System;
using Collision.Source.Modules.Collision.Scripts;
using Source.Modules.Respawner.Scripts;
using UnityEngine;

namespace Game.Source.Modules.Game.Scripts
{
    public class GameRoot : MonoBehaviour
    {
        [SerializeField] private CollisionHandler _collisionHandler;
        [SerializeField] private Movement.Source.Modules.Movement.Scripts.ShipInput _shipInput;
        [SerializeField] private CameraRespawner _cameraRespawner;
        [SerializeField] private ShipRespawner _shipRespawner;
        [SerializeField] private UIRoot _uiRoot;
        
        private void OnEnable()
        {
            _collisionHandler.ObstacleCollided += OnObstacleCollided;
            _collisionHandler.FinishCollided += OnFinishCollided;
        }

        private void OnDisable()
        {
            _collisionHandler.FinishCollided -= OnFinishCollided;
            _collisionHandler.ObstacleCollided -= OnObstacleCollided;
        }

        private void OnFinishCollided()
        {
            _uiRoot.LevelFinish();
        }

        private void Start()
        {
            _shipInput.Enable();
        }

        private void OnObstacleCollided()
        {
            _shipRespawner.Respawn();
            _cameraRespawner.Respawn();
        }
    }
}

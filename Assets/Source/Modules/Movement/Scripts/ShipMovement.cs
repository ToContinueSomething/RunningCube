using System;
using UnityEngine;

namespace Movement.Source.Modules.Movement.Scripts
{
    internal class ShipMovement : Movement
    {
        private const float ShipFirstClickBoost = 1.5f;
        private const float ShipGravity = 4.012969f;
        private const float RotationSpeed = 11.5f;
        private Quaternion _targetRotation;

        private int _gravity = 1;

        private bool _newShipClick = false;
        
        protected override void AddVelocity()
        {
            Shell.rotation = GetRotation();

            Rigidbody.LimitYVelocity(17.8f);
            
            if (Clicking == false) 
                _newShipClick = true;

            if (Clicking)
            {
                Rigidbody.gravityScale = -ShipGravity;
                
                if (_newShipClick) 
                    Rigidbody.velocity += Vector2.up * ShipFirstClickBoost;

                _newShipClick = false;
            }
            else
            {
                Rigidbody.gravityScale = ShipGravity;
            }

            Rigidbody.gravityScale = Rigidbody.gravityScale * _gravity;
        }

        private Quaternion GetRotation()
        {
            _targetRotation = Quaternion.Euler(0, 0, Rigidbody.velocity.y * 2.8f);
            
            return  Quaternion.Slerp(Shell.rotation, _targetRotation,
                    Time.deltaTime * RotationSpeed);
        }
    }
}
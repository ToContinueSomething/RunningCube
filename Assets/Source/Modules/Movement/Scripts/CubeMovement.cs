using UnityEngine;

namespace Movement.Source.Modules.Movement.Scripts
{
    public class CubeMovement : Movement
    {
        private bool _clickProcessed;
        private readonly float _gravity = 1;
        
        protected override void AddVelocity()
        {
            if (!Clicking || OnGround())
                _clickProcessed = false;

            Rigidbody.gravityScale = 9.057f * _gravity;
            Rigidbody.LimitYVelocity(25.9f);

            if (Clicking) {
                if (OnGround() && !_clickProcessed) {
                    _clickProcessed = true;
                    Rigidbody.velocity = Vector2.up * 19.5269f * _gravity;
                }
            }

            if (OnGround()) {
                Shell.rotation = Quaternion.Euler(0, 0, Mathf.Round(Shell.rotation.eulerAngles.z / 90) * 90);
            } else {
                Shell.Rotate(Vector3.back, 409.18f * Time.deltaTime * _gravity);
            }
        }
        

        private bool OnGround()
        {
            return false;
        }
    }
}
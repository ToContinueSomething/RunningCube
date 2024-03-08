using UnityEngine;

namespace Movement.Source.Modules.Movement.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Movement : MonoBehaviour
    {
        [SerializeField] private Transform _shell;
        [SerializeField] private Rigidbody2D _rigidbody;
        
        private bool _isMove;
        private readonly float[] _speedValues = { 8.382f, 10.386f, 12.912f, 15.6f, 19.203f };

        protected Rigidbody2D Rigidbody => _rigidbody;
        protected bool Clicking { get; private set; }

        protected Transform Shell => _shell;
        
        private void FixedUpdate()
        {
            if (_isMove == false)
                return;
            
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
            _rigidbody.position += Vector2.right * _speedValues[1] * Time.deltaTime;
            AddVelocity();
        }

        protected abstract void AddVelocity();

        internal void EnableMove()
        {
            _isMove = true;
        }

        internal void SetClick(bool state)
        {
            Clicking = state;
        }

        internal void DisableMove()
        {
            _isMove = false;
        }
    }
}
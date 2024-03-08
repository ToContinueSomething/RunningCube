using UnityEngine;

namespace Movement.Source.Modules.Movement.Scripts
{
    public class ShipInput : MonoBehaviour
    {
        [SerializeField] private ShipMovement _movement;

        private global::ShipInput _input;
        private bool _state;

        private void Awake()
        {
            _input = new global::ShipInput();
            _input.Enable();
        }

        public void Enable()
        {
            _input.Enable();
            _movement.EnableMove();
        }

        private void Update()
        {
            _state = _input.Player.Move.ReadValue<float>() >= 1;
            _movement.SetClick(_state);
        }

        public void Disable()
        {
            _input.Disable();
            _movement.DisableMove();
        }
    }
}
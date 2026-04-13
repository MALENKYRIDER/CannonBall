using UnityEngine;
using UnityEngine.InputSystem;

namespace System.InputSystem
{
    public class InputSystem : MonoBehaviour
    {
        private InputSystem_Actions _actions;

        public event Action FirePressed;
        public Vector2 LookPosition => _actions.Player.Look.ReadValue<Vector2>(); 

        private void Awake()
        {
            _actions = new InputSystem_Actions();
        }

        private void OnEnable()
        {
            _actions.Enable();
            _actions.Player.Attack.performed += OnAtteck;
        }

        private void OnDisable()
        {
            _actions.Disable();
            _actions.Player.Attack.performed -= OnAtteck;
        }

        private void OnAtteck(InputAction.CallbackContext obj) => FirePressed?.Invoke();
    }
}

using System.InputSystem;
using UnityEngine;

namespace CannonControl
{
    public class CannonPivotReducer : MonoBehaviour
    {
        [SerializeField] private Vector2 _factor;
        [SerializeField] private InputSystem _input;
        [SerializeField] private CannonPivot _pivot;
        
        private void Update()
        {
            _pivot.Rotate(new Vector2(
                -_input.LookPosition.y,
                _input.LookPosition.x) / _factor);
        }
    }
}
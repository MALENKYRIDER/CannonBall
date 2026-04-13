using System;
using System.InputSystem;
using UnityEngine;

namespace CannonControl
{
    public class CannonPivot : MonoBehaviour
    {
        [SerializeField] private Limits _limits;

        private Vector2 _rotateDirection;

        public void Rotate(Vector2 direction)
        {
            _rotateDirection = new Vector2(
                Math.Clamp(_rotateDirection.x + direction.x, _limits.VerticalMin, _limits.VerticalMax),
                Math.Clamp(_rotateDirection.y + direction.y,  _limits.HorizontalMin, _limits.HorizontalMax));
            transform.rotation = Quaternion.Euler(_rotateDirection);
        }

        private void Start()
        {
            _rotateDirection = transform.rotation.eulerAngles;
        }

        [Serializable]
        private class Limits
        {
            public float VerticalMin;
            public float VerticalMax;
            public float HorizontalMin;
            public float HorizontalMax;
        }
    }
}
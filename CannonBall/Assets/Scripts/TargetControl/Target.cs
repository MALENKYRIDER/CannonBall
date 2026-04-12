using System;
using UnityEngine;

namespace TargetControl
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private TargetModel _model;
        [SerializeField] private TargetCollider _collider;

        public event Action Hit;
        
        private void OnEnable()
        {
            _collider.Hit += OnHit;
        }

        private void OnDisable()
        {
            _collider.Hit -= OnHit;
        }

        private void OnHit()
        {
            Hit?.Invoke();
            _model.AnimateHit();
        }
        
        private void OnValidate()
        {
            if (_model == null)
            {
                var component = GetComponentInChildren<TargetModel>();

                if (component == null)
                    Debug.LogError($"Component was not found on {gameObject.name}", this);
                else
                    _model = component;
            }

            if (_collider == null)
            {
                var component = GetComponentInChildren<TargetCollider>();

                if (component == null)
                    Debug.LogError($"Component was not found on {gameObject.name}", this);
                else
                    _collider = component;
            }
        }
    }
}
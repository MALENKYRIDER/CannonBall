using System;
using UnityEngine;

namespace TargetControl
{
    public class TargetGroup : MonoBehaviour
    {
        [SerializeField] private Target[] _targets;

        public event Action Hit;
        
        private void OnEnable()
        {
            foreach (var target in _targets) 
                target.Hit += OnHit;
        }
        
        private void OnDisable()
        {
            foreach (var target in _targets) 
                target.Hit -= OnHit;
        }

        private void OnHit()
        {
            Hit?.Invoke();
        }

        private void OnValidate()
        {
            if (_targets == null || _targets.Length == 0) 
                _targets = GetComponentsInChildren<Target>();
        }
    }
}
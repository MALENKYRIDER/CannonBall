using System;
using UnityEngine;

namespace TargetControl
{
    public class TargetCollider : MonoBehaviour
    {
        public event Action Hit;
        
        private void OnCollisionEnter()
        {
            Hit?.Invoke();
        }
    }
}
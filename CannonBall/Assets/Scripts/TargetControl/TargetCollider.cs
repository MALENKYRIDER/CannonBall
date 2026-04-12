using System;
using System.Collections;
using UnityEngine;

namespace TargetControl
{
    public class TargetCollider : MonoBehaviour
    {
        private Collider _collider;
        
        public event Action Hit;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
        }

        private void OnCollisionEnter()
        {
            Hit?.Invoke();
            StartCoroutine(DisableCollider());
        }

        private IEnumerator DisableCollider()
        {
            _collider.enabled = false;
            yield return new WaitForSeconds(2f);
            _collider.enabled = true;
        }
    }
}
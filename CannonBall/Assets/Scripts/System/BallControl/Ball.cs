using UnityEngine;

namespace BallControl
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        public void SetUp(Vector3 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;
            _rigidbody.angularVelocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }
        
        public void Apply(Vector3 force)
        {
            _rigidbody.AddForce(force, ForceMode.Impulse);
        }
        
        private void OnValidate()
        {
            if (_rigidbody != null) 
                return;
            
            var component = GetComponent<Rigidbody>();

            if (component == null)
                Debug.LogError($"Component Rigidbody was not found on {gameObject.name}", this);
            else
                _rigidbody = component;
        }
    }
}

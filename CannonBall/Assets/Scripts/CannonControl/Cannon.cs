using System.InputSystem;
using BallControl;
using UnityEngine;

namespace CannonControl
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] private float _power = 100f;
        [SerializeField] private BallPool _ballPool;
        [SerializeField] private InputSystem _input;
        [SerializeField] private Transform _spawnPoint;

        private void OnEnable()
        {
            _input.FirePressed += OnFirePressed;
        }

        private void OnDisable()
        {
            _input.FirePressed -= OnFirePressed;
        }

        private void OnFirePressed()
        {
            var ball = _ballPool.Get();
            ball.SetUp(_spawnPoint.position, _spawnPoint.rotation);
            ball.Apply(_spawnPoint.forward * _power);
        }
    }
}
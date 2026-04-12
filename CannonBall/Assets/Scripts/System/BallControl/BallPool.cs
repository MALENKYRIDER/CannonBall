using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BallControl
{
    public class BallPool : MonoBehaviour
    {
        [SerializeField] private Ball _prefab;

        private Queue<Ball> _pool = new();

        public Ball Get()
        {
            if (_pool.TryDequeue(out var ball))
            {
                ball.gameObject.SetActive(true);
            }
            else
            {
                ball = Instantiate(_prefab);
            }

            StartCoroutine(Deactivate(ball));
            return ball;
        }

        private IEnumerator Deactivate(Ball ball)
        {
            yield return new WaitForSeconds(5);
            _pool.Enqueue(ball);
            ball.gameObject.SetActive(false);
        }
    }
}
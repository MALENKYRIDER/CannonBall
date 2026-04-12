using DG.Tweening;
using UnityEngine;

namespace TargetControl
{
    public class TargetModel : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _renderer;
        
        private Color _defaultColor;
        private Vector3 _defaultScale;
        private Sequence _sequence;

        public void AnimateHit()
        {
            _sequence?.Kill();

            _renderer.transform.localScale = _defaultScale;
            _sequence = DOTween.Sequence();
            _sequence.Append(
                _renderer.material.DOColor(Color.red, 0.3f));
            _sequence.Join(
                _renderer.transform.DOPunchScale(_defaultScale * 1.2f, 0.5f));
            _sequence.AppendInterval(0.2f);
            _sequence.Append(
                _renderer.material.DOColor(_defaultColor, 0.3f));
        }

        private void Start()
        {
            _defaultColor = _renderer.material.color;
            _defaultScale = _renderer.transform.localScale;
        }

        private void OnValidate()
        {
            if (_renderer == null)
            {
                var component = GetComponentInChildren<MeshRenderer>();

                if (component == null)
                    Debug.LogError($"Component was not found on {gameObject.name}", this);
                else
                    _renderer = component;
            }
        }
    }
}
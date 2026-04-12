using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace TargetControl
{
    public class TargetModel : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private Transform _target;

        private Color _defaultColor;
        private Vector3 _defaultScale;
        private Sequence _sequence;

        private void Start()
        {
            _defaultColor = _renderer.material.color;
            _defaultScale = _renderer.transform.localScale;

            _target.DOLocalMoveY(0.5f, 1f)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine);
        }

        public void AnimateHit()
        {
            _sequence?.Kill();

            _renderer.transform.localScale = _defaultScale;

            _sequence = DOTween.Sequence();

            _sequence.Append(
                _renderer.material.DOColor(Color.red, 0.3f));
            _sequence.Join(
                _renderer.transform.DOScale(_defaultScale * 0.7f, 0.2f));
            _sequence.AppendInterval(1f);
            _sequence.Append(
                _renderer.material.DOColor(_defaultColor, 0.3f));
            _sequence.Append(
                _renderer.transform.DOScale(_defaultScale, 0.3f));
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
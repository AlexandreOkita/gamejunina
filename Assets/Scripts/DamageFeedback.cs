using DG.Tweening;
using healthSystem;
using UnityEngine;

namespace DefaultNamespace
{
    public class DamageFeedback : MonoBehaviour
    {
        [SerializeField] Health _health;
        [SerializeField] DamageText _damagePrefab;
        [SerializeField] SpriteRenderer _mainRenderer;
        [SerializeField] Color _damageColor;
        [SerializeField, Range(0, 4f)] float _effectDuration;

        void Start()
        {
            _health.OnDamageReceived += ShowFeedback;
        }

        void ShowFeedback(float damage)
        {
            var feedback = Instantiate(_damagePrefab, transform.position, Quaternion.identity);
            feedback.Setup(damage);
            TweenParams tParms = new TweenParams().SetLoops(2).SetEase(Ease.Flash);
            _mainRenderer.DOColor(_damageColor, _effectDuration).SetAs(tParms).OnComplete(() => _mainRenderer.color = Color.white);
        }

        void OnDestroy()
        {
            _health.OnDamageReceived -= ShowFeedback;
        }
    }
}
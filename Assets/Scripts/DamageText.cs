using DG.Tweening;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class DamageText : MonoBehaviour
    {
        [SerializeField] float _effectDuration;
        [SerializeField] TMP_Text _damageText;
        [SerializeField] Renderer _renderer;

        public void Setup(float damage)
        {
            _damageText.text = damage.ToString();
            transform.localScale = 0.4f * Vector3.one;
            transform.DOLocalMoveY(2 * Mathf.Sign(transform.position.y), _effectDuration);
            transform.DOPunchScale(Vector3.one * 1.5f, _effectDuration / 2f, vibrato: 1, elasticity: 1).OnComplete(() => Destroy(gameObject));
            // _renderer.material.DOFade(0, _effectDuration);
        }
    }
}
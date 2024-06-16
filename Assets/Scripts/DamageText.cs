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
            transform.localScale = 0.2f * Vector3.one;
            transform.DOLocalMoveY(2, _effectDuration);
            transform.DOPunchScale(Vector3.one, _effectDuration / 2f, vibrato: 1, elasticity: 1).OnComplete(() => Destroy(gameObject));
            // _renderer.material.DOFade(0, _effectDuration);
        }
    }
}
using System;
using healthSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class HealthHud : MonoBehaviour
    {
        [SerializeField] RectTransform _healthUi;
        [SerializeField] Image _healthBar;
        [SerializeField] TMP_Text _lifeText;

        Health _bindedHealth;

        public void Setup(Health health, Color color)
        {
            _healthUi.sizeDelta = new Vector2( 32f, _healthUi.sizeDelta.y);
            _bindedHealth = health;
            _healthBar.color = color;
            health.OnDamageReceived += UpdateUi;
            health.OnHealthHealed += UpdateUi;
            health.OnMaxHealthUpdated += UpdateUi;
            _lifeText.text = $"{_bindedHealth.CurrentHealth}/{_bindedHealth.MaxHealth}";
        }

        void UpdateUi(float _)
        {
            _healthUi.sizeDelta = new Vector2( 32f * _bindedHealth.CurrentHealth / _bindedHealth.MaxHealth, _healthUi.sizeDelta.y);
            _lifeText.text = $"{_bindedHealth.CurrentHealth}/{_bindedHealth.MaxHealth}";
        }

        void OnDestroy()
        {
            if (_bindedHealth != null) _bindedHealth.OnDamageReceived -= UpdateUi;
        }
    }
}
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
        [SerializeField] System.Collections.Generic.List<Image> _skillSlots;

        Health _bindedHealth;

        public void Setup(PlayerController player)
        {
            _healthUi.sizeDelta = new Vector2( 32f, _healthUi.sizeDelta.y);
            _bindedHealth = player.Health;
            _healthBar.color = player.PlayerColor;
            player.Health.OnDamageReceived += UpdateUi;
            player.Health.OnHealthHealed += UpdateUi;
            player.Health.OnMaxHealthUpdated += UpdateUi;
            _lifeText.text = $"{_bindedHealth.CurrentHealth}/{_bindedHealth.MaxHealth}";
            player.OnSkillAdded += (skillSlotPair) =>
            {
                AddSkill(skillSlotPair.Item1, skillSlotPair.Item2);
            };
        }

        public void AddSkill(ISkill skill, int slot)
        {
            Image skillSlot = _skillSlots[(slot) % 3];
            skillSlot.sprite = skill.Sprite;
            skillSlot.gameObject.SetActive(true);
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
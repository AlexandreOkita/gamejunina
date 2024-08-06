using System;
using System.Collections;
using System.Linq;
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
        private System.Collections.Generic.List<Tuple<float, float>> _slotsCooldown;

        Health _bindedHealth;

        public void Setup(PlayerController player)
        {
            _slotsCooldown = Enumerable.Repeat(new Tuple<float, float>(0, 0), _skillSlots.Count()).ToList();
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
            player.OnSkillUsed += (skillSlotPair) =>
            {
                StartCoroutine(UseSkill(skillSlotPair.Item1, skillSlotPair.Item2, 0));
            };
        }

        private IEnumerator UseSkill(ISkill skill, int slot, float currentCooldown)
        {
            if (currentCooldown > skill.Cooldown) yield break;
            _skillSlots[slot].fillAmount = currentCooldown / skill.Cooldown;
            yield return new WaitForSeconds(1f);
            currentCooldown += 1;
            StartCoroutine(UseSkill(skill, slot, currentCooldown));
        }

        void AddSkill(ISkill skill, int slot)
        {
            Image skillSlot = _skillSlots[slot];
            skillSlot.sprite = skill.Sprite;
            skillSlot.gameObject.SetActive(true);
            _slotsCooldown[slot] = new Tuple<float, float>(skill.Cooldown, skill.Cooldown);
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
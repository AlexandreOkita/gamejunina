using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Roguelike
{
    [RequireComponent(typeof(AudioSource))]
    public class UpgradeButton : MonoBehaviour
    {
        [SerializeField] TMP_Text title;
        [SerializeField] TMP_Text description;
        [SerializeField] Image image;
        [SerializeField] Button button;

        private AudioSource source;

        // Start is called before the first frame update
        private void Start()
        {
            source = GetComponent<AudioSource>();
        }

        public void Setup(AttributeUpgrade upgrade, PlayerController player, Action selected)
        {
            title.text = upgrade.title;
            description.text = upgrade.description;
            image.sprite = upgrade.sprite;
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() =>
            {
                source.clip = upgrade.sound;
                source.Play();
                switch (upgrade.type)
                {
                    case UpgradeType.HEALTH:
                        player.upgradeHealth();
                        break;
                    case UpgradeType.ATTACK_SPEED:
                        player.upgradeAttackSpeed();
                        break;
                    case UpgradeType.DAMAGE:
                        player.upgradeAttack();
                        break;
                    case UpgradeType.TRIPLE_WEAPON:
                        player.UpdateWeapon(upgrade.weapon);
                        break;
                    case UpgradeType.ALL_DIRECTIONS:
                        player.UpdateWeapon(upgrade.weapon);
                        break;
                    case UpgradeType.SPEED:
                        player.upgradeSpeed();
                        break;
                    case UpgradeType.REGEN:
                        player.upgradeRegen();
                        break;
                    case UpgradeType.WEAPON_PIERCE:
                        player.UpdateWeapon(upgrade.weapon);
                        break;
                }
                selected?.Invoke();
            });
        }
    }
}

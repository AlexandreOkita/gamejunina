using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Roguelike
{
    public class UpgradeButton : MonoBehaviour
    {
        [SerializeField] TMP_Text title;
        [SerializeField] TMP_Text description;
        [SerializeField] Image image;
        [SerializeField] Button button;

        [SerializeField] AudioSource source;
        [SerializeField] AudioClip healthSound;
        [SerializeField] AudioClip attackSpeedSound;
        [SerializeField] AudioClip damageSound;
        [SerializeField] AudioClip tripleWeaponSound;
        [SerializeField] AudioClip allDirWeaponSound;
    
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
                switch(upgrade.type)
                {
                    case UpgradeType.HEALTH:
                        player.upgradeHealth();
                        //source.clip = healthSound;
                        //source.Play();
                        break;
                    case UpgradeType.ATTACK_SPEED:
                        player.upgradeAttackSpeed();
                        //source.clip = attackSpeedSound;
                        //source.Play();
                        break;
                    case UpgradeType.DAMAGE:
                        player.upgradeAttack();
                        //source.clip = damageSound;
                        //source.Play();
                        break;
                    case UpgradeType.TRIPLE_WEAPON:
                        player.UpdateWeapon(upgrade.weapon);
                        //source.clip = tripleWeaponSound;
                        //source.Play();
                        break;
                    case UpgradeType.ALL_DIRECTIONS:
                        player.UpdateWeapon(upgrade.weapon);
                        //source.clip = allDirWeaponSound;
                        //source.Play();
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

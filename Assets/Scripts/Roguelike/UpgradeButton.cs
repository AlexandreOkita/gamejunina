using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] TMP_Text title;
    [SerializeField] TMP_Text description;
    [SerializeField] Image image;
    [SerializeField] Button button;
    [SerializeField] AttackBase trippleWeapon;
    // Start is called before the first frame update
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
                    break;
                case UpgradeType.ATTACK_SPEED:
                    player.upgradeAttackSpeed();
                    break;
                case UpgradeType.DAMAGE:
                    player.upgradeAttack();
                    break;
                case UpgradeType.TRIPLE_WEAPON:
                    player.UpdateWeapon(trippleWeapon);
                    break;
            }
            selected?.Invoke();
        });
    }
}

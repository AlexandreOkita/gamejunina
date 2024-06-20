using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Game/Upgrades/Weapon")]
public class WeaponUpgrade : AttributeUpgrade
{
    [SerializeField] AttackBase weapon;
    public override void Apply(PlayerController player)
    {
        player.UpdateWeapon(weapon);
    }

    public override UpgradeType GetUpgradeType()
    {
        return UpgradeType.WEAPON;
    }
}

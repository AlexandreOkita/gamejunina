using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Game/Upgrades/Attributes/AttackSpeed")]
public class AttackSpeedAttributeUpgrade : AttributeUpgrade
{
    [SerializeField] float attackSpeedBonus = (float) 0.5;
    public override void Apply(PlayerController player)
    {
        player.Attributes.UpgradeAttackSpeed(attackSpeedBonus);
    }

    public override UpgradeType GetUpgradeType()
    {
        return UpgradeType.ATTRIBUTE;
    }
}

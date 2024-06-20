using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Game/Upgrades/Attributes/Attack")]
public class AttackAttributeUpgrade : AttributeUpgrade
{
    [SerializeField] float attackBonus = (float) 0.5;
    public override void Apply(PlayerController player)
    {
        player.Attributes.UpgradeAttack(attackBonus);
    }

    public override UpgradeType GetUpgradeType()
    {
        return UpgradeType.ATTRIBUTE;
    }
}

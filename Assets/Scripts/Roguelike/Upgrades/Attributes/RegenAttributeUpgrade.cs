using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Game/Upgrades/Attributes/Regen")]
public class RegenAttributeUpgrade : AttributeUpgrade
{
    [SerializeField] float regenBonus = 25;
    public override void Apply(PlayerController player)
    {
        player.Attributes.UpgradeRegen(regenBonus);
    }

    public override UpgradeType GetUpgradeType()
    {
        return UpgradeType.ATTRIBUTE;
    }
}

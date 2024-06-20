using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Game/Upgrades/Attributes/Speed")]
public class SpeedAttributeUpgrade : AttributeUpgrade
{
    [SerializeField] float speedBonus = (float) 1.5;
    public override void Apply(PlayerController player)
    {
        player.Attributes.UpgradeSpeed(speedBonus);
    }

    public override UpgradeType GetUpgradeType()
    {
        return UpgradeType.ATTRIBUTE;
    }
}

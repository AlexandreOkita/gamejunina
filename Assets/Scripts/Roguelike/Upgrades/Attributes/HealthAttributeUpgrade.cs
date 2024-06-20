using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Game/Upgrades/Attributes/Health")]
public class HealthAttributeUpgrade : AttributeUpgrade
{
    [SerializeField] float healthBonus = 25;
    public override void Apply(PlayerController player)
    {
        player.Attributes.UpgradeHealth(healthBonus);
    }

    public override UpgradeType GetUpgradeType()
    {
        return UpgradeType.ATTRIBUTE;
    }
}

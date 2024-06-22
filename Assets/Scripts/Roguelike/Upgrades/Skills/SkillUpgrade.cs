using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Game/Upgrades/Skill")]
public class SkillUpgrade : AttributeUpgrade
{
    [SerializeField] ISkill skill;
    public override void Apply(PlayerController player)
    {
        player.SkillCaster.AddSkill(skill);
    }

    public override UpgradeType GetUpgradeType()
    {
        return UpgradeType.SKILL;
    }
}

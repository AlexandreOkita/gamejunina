using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Game/Upgrades")]
public class AttributeUpgrade : ScriptableObject
{
    public string title;
    public string description;
    public UpgradeType type;
    public Sprite sprite;
    public AttackBase weapon;
}

public enum UpgradeType
{
    HEALTH,
    DAMAGE,
    ATTACK_SPEED,
    TRIPLE_WEAPON,
    ALL_DIRECTIONS,
    SPEED,
    REGEN
}

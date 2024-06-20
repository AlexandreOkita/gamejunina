using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Game/Upgrades")]
public abstract class AttributeUpgrade : ScriptableObject
{
    public string title;
    public string description;
    public Sprite sprite;
    public AudioClip sound;

    public abstract UpgradeType GetUpgradeType();
    public abstract void Apply(PlayerController player);
}

public enum UpgradeType
{
    ATTRIBUTE,
    WEAPON,
    SKILL
}

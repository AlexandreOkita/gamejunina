using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Game/Upgrades")]
public class AttributeUpgrade : ScriptableObject
{
    public string title;
    public string description;
    public Sprite sprite;
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Game/Skills")]
abstract public class ISkill: ScriptableObject
{
    [SerializeField] float _cooldown = 15;
    [SerializeField] Sprite _sprite;
    public float Cooldown => _cooldown;
    public Sprite Sprite => _sprite;
    abstract public void Cast(PlayerController player);
}

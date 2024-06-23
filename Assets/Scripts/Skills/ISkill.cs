using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Skills")]
abstract public class ISkill: ScriptableObject
{
    [SerializeField] float _cooldown = 15;
    public float Cooldown => _cooldown;
    abstract public void Cast(PlayerController player);
}

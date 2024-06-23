using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Skills/Invisibility")]
public class Invisibility : ISkill
{
    [SerializeField] float duration = 5;
    public override void Cast(PlayerController player)
    {
        player.StartBlink(duration, (float)0.2);
        player.TurnOnInvisibility(duration);
    }
}

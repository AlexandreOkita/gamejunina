using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Skills")]
abstract public class ISkill: ScriptableObject
{
    abstract public void Cast(PlayerController player);
}

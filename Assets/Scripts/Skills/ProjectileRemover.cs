using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Skills/ProjectileRemover")]
public class ProjectileRemover : ISkill
{
    public override void Cast()
    {
        GlobalEvents.Instance.OnDestroyProjectiles.Invoke();
    }
}

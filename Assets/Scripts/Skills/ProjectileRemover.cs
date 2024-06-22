using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRemover : ISkill
{
    public void Cast()
    {
        GlobalEvents.Instance.OnDestroyProjectiles.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBase : MonoBehaviour
{
    public List<Transform> launchPoints;
    public ProjectileMovement projectile;
    public float attackCooldown = 1f;
    private float lastAttackTime = 0f;

    public void TryAttack(float attackSpeed, float damageMod)
    {
        if (Time.time >= lastAttackTime + attackCooldown*attackSpeed)
        {
            Attack(damageMod);
            lastAttackTime = Time.time;
        }
    }

    private void Attack(float damageMod)
    {
        foreach (var launchPoint in launchPoints)
        {
            var p = Instantiate(projectile, launchPoint.position, launchPoint.rotation);
            p.damage *= damageMod;
        }
    }
}

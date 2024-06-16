using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBase : MonoBehaviour
{
    public List<Transform> launchPoints;
    public GameObject projectile;
    public float attackCooldown = 1f;
    private float lastAttackTime = 0f;

    public void TryAttack()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }

    private void Attack()
    {
        foreach (var launchPoint in launchPoints)
        {
            Instantiate(projectile, launchPoint.position, launchPoint.rotation);
        }
    }
}

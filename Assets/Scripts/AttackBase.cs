using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBase : MonoBehaviour
{
    public List<Transform> launchPoints;
    public GameObject projectile;

    public void Attack()
    {
        foreach (var launchPoint in launchPoints)
        {
            Instantiate(projectile, launchPoint.position, launchPoint.rotation);
        };
    }
}

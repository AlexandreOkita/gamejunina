using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBase : MonoBehaviour
{
    public List<Transform> launchPoints;
    public GameObject projectile;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var launchPoint in launchPoints)
            {
                Instantiate(projectile, launchPoint.position, launchPoint.rotation);
            };
        }
    }
}

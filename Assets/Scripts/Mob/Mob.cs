using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using healthSystem;

public class Mob : MonoBehaviour
{
    [SerializeField] Health health;
    // Start is called before the first frame update
    void Start()
    {
        health.OnDeath += () =>
        {
            Destroy(gameObject);
        };
    }
}

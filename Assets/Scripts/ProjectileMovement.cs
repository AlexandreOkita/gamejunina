using healthSystem;
using UnityEngine;
// ReSharper disable All

public class ProjectileMovement : MonoBehaviour, ITeleportable
{

    [SerializeField] private float speed = 10f;
    [SerializeField] private float damage = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * (speed * Time.deltaTime));
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable health = other.GetComponent<IDamageable>();
        if (health == null) return;
        health.TakeDamage(damage);
        Destroy(gameObject);
    }
}

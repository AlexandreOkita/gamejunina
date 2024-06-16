using DG.Tweening;
using healthSystem;
using UnityEngine;
// ReSharper disable All

public class ProjectileMovement : MonoBehaviour, ITeleportable
{

    [SerializeField] private float speed = 10f;
    [SerializeField] public float damage = 10f;
    [SerializeField] private bool hitMobs = true;

    bool _isDisposing;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * (speed * Time.deltaTime));
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (_isDisposing) return;

        IDamageable health = other.GetComponent<IDamageable>();
        if (hitMobs || health.IsPlayer())
        {
            if (health == null) return;
            health.TakeDamage(damage);
        }
        StartDestroy();
    }

    void StartDestroy()
    {
        _isDisposing = true;
        transform.DOScale(Vector3.zero, 0.2f).OnComplete(() => Destroy(gameObject));
        this.enabled = false;
    }
}

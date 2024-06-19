using DG.Tweening;
using healthSystem;
using UnityEngine;
// ReSharper disable All

public class ProjectileMovement : MonoBehaviour, ITeleportable
{
    [SerializeField] private float speed = 10f;
    [SerializeField] public float damage = 10f;
    [SerializeField] private bool hitMobs = true;

    private bool _isDisposing;

    void Start()
    {
        LevelManager.Instance.NewLevelStarted += () =>
        {
            StartDestroy();
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isDisposing)
        {
            transform.Translate(Vector3.right * (speed * Time.deltaTime));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (_isDisposing) return;

        IDamageable health = other.GetComponent<IDamageable>();
        if (health == null) return;

        if (hitMobs || health.IsPlayer())
        {
            health.TakeDamage(damage);
        }
        StartDestroy();
    }

    void StartDestroy()
    {
        if (_isDisposing) return; // Evita múltiplas chamadas
        _isDisposing = true;
        this.enabled = false; // Desabilita o script para evitar mais chamadas de Update

        // Verifica se o objeto ainda existe antes de destruir
        transform.DOScale(Vector3.zero, 0.2f).OnComplete(() =>
        {
            if (this != null) // Verifica se o objeto ainda não foi destruído
            {
                Destroy(gameObject);
            }
        });
    }
}

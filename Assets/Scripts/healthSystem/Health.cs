using System;
using UnityEngine;
// ReSharper disable All

namespace healthSystem
{
    public class Health : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _maxHealth;

        public event Action<float> OnDamageReceived;
        public event Action OnDeath;
        
        public float CurrentHealth { get; private set; }
        public float MaxHealth => _maxHealth;

        private HealthLogger _logger;

        private void Start()
        {
            CurrentHealth = MaxHealth;
            _logger = new HealthLogger(this);
        }

        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                OnDeath?.Invoke();
            }
            else
            {
                OnDamageReceived?.Invoke(damage);
            }
        }

        private void OnDestroy()
        {
            _logger?.Dispose();
        }
    }
}



using System;
using UnityEngine;
// ReSharper disable All

namespace healthSystem
{
    public class Health : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private bool isPlayer;

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

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.O)) OnDeath?.Invoke();
        }

        public void TakeDamage(float damage)
        {
            if (CurrentHealth <= 0) return; // Already dead

            CurrentHealth -= damage;
            OnDamageReceived?.Invoke(damage);
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                OnDeath?.Invoke();
            }
        }

        private void OnDestroy()
        {
            _logger?.Dispose();
        }

        bool IDamageable.IsPlayer()
        {
            return isPlayer;
        }
    }
}



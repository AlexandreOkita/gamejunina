using System;
using UnityEngine;
// ReSharper disable All

namespace healthSystem
{
    public class Health : MonoBehaviour, IDamageable
    {
        [SerializeField] private float maxHealthBase;
        [SerializeField] private bool isPlayer;

        public event Action<float> OnDamageReceived;
        public event Action OnDeath;
        
        public float CurrentHealth { get; set; }
        public float MaxHealth => currentMaxHealth;
        public bool IsAlive => CurrentHealth > 0;

        private HealthLogger _logger;
        private float currentMaxHealth;

        private void Awake()
        {
            currentMaxHealth = maxHealthBase;
            CurrentHealth = currentMaxHealth;
            _logger = new HealthLogger(this);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.O)) OnDeath?.Invoke();
        }

        public void SetMaxHealth(float val)
        {
            var diff = val - currentMaxHealth;
            currentMaxHealth = val;
            CurrentHealth += diff;
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



using System;
using UnityEngine;
// ReSharper disable All

namespace healthSystem
{
    public class Health : MonoBehaviour, IDamageable
    {
        [SerializeField] private float maxHealthBase;
        [SerializeField] private bool isPlayer;
        [SerializeField] private float reviveTax = 0.4f;

        public event Action<float> OnDamageReceived;
        public event Action OnDeath;
        public event Action<float> OnHealthHealed;
        public event Action<float> OnMaxHealthUpdated;
        
        public float CurrentHealth { get; private set; }
        public float MaxHealth => currentMaxHealth;
        public bool IsAlive => CurrentHealth > 0;

        private HealthLogger _logger;
        private float currentMaxHealth;

        private void Awake()
        {
            currentMaxHealth = maxHealthBase;
            CurrentHealth = currentMaxHealth;
            OnMaxHealthUpdated?.Invoke(currentMaxHealth);
            _logger = new HealthLogger(this);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                if (!isPlayer)
                OnDeath?.Invoke();
            }
        }

        public void SetMaxHealth(float val)
        {
            var diff = val - currentMaxHealth;
            currentMaxHealth = val;
            CurrentHealth += diff;
            OnMaxHealthUpdated?.Invoke(val);
        }

        public void Revive()
        {
            CurrentHealth = currentMaxHealth * reviveTax;
        }

        public void HealDamage(float heal)
        {
            if (CurrentHealth <= 0) return; // Already dead

            CurrentHealth = Mathf.Min(MaxHealth, CurrentHealth + heal);
            OnHealthHealed?.Invoke(heal);
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                OnDeath?.Invoke();
            }
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



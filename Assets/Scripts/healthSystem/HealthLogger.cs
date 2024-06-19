using System;
using UnityEngine;

namespace healthSystem
{
    public class HealthLogger : IDisposable
    {
        private readonly Health _health;

        public HealthLogger(Health health)
        {
            _health = health;
            _health.OnDeath += LogDeath;
            _health.OnDamageReceived += LogDamage;
        }

        void LogDeath() => Debug.Log($"GameObject {_health.name} morreu", _health);
        void LogDamage(float damage) => Debug.Log($"GameObject {_health.name} took {damage} damage. Current health {_health.CurrentHealth}", _health);

        public void Dispose()
        {
            if (_health == null) return;
            _health.OnDeath -= LogDeath;
            _health.OnDamageReceived -= LogDamage;
        }
    }
}
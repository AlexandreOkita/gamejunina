using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using healthSystem;

public class Mob : MonoBehaviour
{
    static int DEAD_PARAMETER_HASH = Animator.StringToHash("Dead");

    [SerializeField] Health health;
    [SerializeField] Animator _animator;
    [SerializeField] NewBehaviourScript _follow;
    [SerializeField] Collider2D _collider;

    public Health Health => health;
    // Start is called before the first frame update

    bool _isDying;

    void Start()
    {
        health.OnDeath += () =>
        {
            StartCoroutine(PerformDeath());
            // Destroy(gameObject);
        };
    }

    public void SetHealth(float val)
    {
        health.SetMaxHealth(val);
    }

    IEnumerator PerformDeath()
    {
        if (_isDying) yield break;
        _isDying = true;

        _animator.SetTrigger(DEAD_PARAMETER_HASH);
        _collider.enabled = false;
        _follow.enabled = false;

        yield return new WaitForSeconds(1.5f);

        Destroy(gameObject);
    }
}

public static class MobExtensions
{
    public static Mob WithHealthModified(this Mob mob, float mod)
    {
        Debug.Log($"Updating health from {mob.Health.MaxHealth} to {mob.Health.MaxHealth * mod}");
        mob.SetHealth(mob.Health.MaxHealth * mod);
        return mob;
    }
}

public class MobProperties
{
    public float HealthMod;
    public Mob Mob;

    public MobProperties(Mob mob, float healthMod)
    {
        HealthMod = healthMod;
        Mob = mob;
    }
}
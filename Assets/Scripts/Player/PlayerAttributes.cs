using System.Collections;
using System.Collections.Generic;
using healthSystem;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    [SerializeField] float attack;
    public float Attack => attack;

    [SerializeField] float attackSpeed;
    public float AttackSpeed => attackSpeed;

    [SerializeField] float regen;
    public float Regen => regen;

    [SerializeField] Health health;
    public Health Health => health;

    [SerializeField] PlayerMovement _movement;
    public PlayerMovement Movement => _movement;

    public void UpgradeAttack(float val)
    {
        attack += val;
    }

    public void UpgradeAttackSpeed(float val)
    {
        attackSpeed *= val;
    }

    public void UpgradeHealth(float val)
    {
        health.SetMaxHealth(health.MaxHealth + val);
    }

    public void UpgradeSpeed(float val)
    {
        _movement.UpdateSpeed(val);
    }

    public void UpgradeRegen(float val)
    {
        regen += val;
    }
}

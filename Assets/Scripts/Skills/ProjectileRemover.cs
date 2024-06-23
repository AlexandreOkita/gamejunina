using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Skills/ProjectileRemover")]
public class ProjectileRemover : ISkill
{
    [SerializeField] ParticleSystem _particleSystem;
    public override void Cast(PlayerController player)
    {
        GlobalEvents.Instance.OnDestroyProjectiles.Invoke();
        EmitParticles(player);
    }

    private void EmitParticles(PlayerController player)
    {
        ParticleSystem particleSystemInstance = Instantiate(_particleSystem, player.transform.position, Quaternion.identity).GetComponent<ParticleSystem>();

        if (particleSystemInstance != null)
        {
            particleSystemInstance.Play();
            Destroy(particleSystemInstance.gameObject, particleSystemInstance.main.duration);
        }

    }
}

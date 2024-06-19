using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float cooldown = 10f;
    private int mobsSpawned = 0;
    private List<MobProperties> mobQueue = new();
    public int RemainingMobs { get; private set; }

    public void StartSpawning()
    {
        RemainingMobs = mobQueue.Count;
        StartCoroutine(SpawnMobs());
    }

    public void ResetSpawner()
    {
        mobsSpawned = 0;
        mobQueue = new();
    }

    public void AddMobToQueue(MobProperties mob)
    {
        mobQueue.Add(mob);
    }

    IEnumerator SpawnMobs()
    {
        while (mobsSpawned < mobQueue.Count)
        {
            var mobProps = mobQueue[mobsSpawned];
            Mob spawnedMob = Instantiate(mobProps.Mob, transform.position, Quaternion.identity);
            spawnedMob.SetHealth(spawnedMob.Health.MaxHealth * mobProps.HealthMod);
            spawnedMob.Health.OnDeath += () =>
            {
                RemainingMobs--;
            };
            mobsSpawned++;

            yield return new WaitForSeconds(cooldown);
        }
    }

}

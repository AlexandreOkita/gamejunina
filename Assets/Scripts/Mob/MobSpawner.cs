using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float cooldown = 10f;
    [SerializeField] private Mob mob;
    private int mobsSpawned = 0;
    private List<Mob> mobQueue;
    public int RemainingMobs { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        RemainingMobs = 0;
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnMobs());
    }

    public void AddMobToQueue(Mob mob)
    {
        mobQueue.Add(mob);
    }

    IEnumerator SpawnMobs()
    {
        yield return new WaitForSeconds(cooldown);

        while (mobsSpawned < mobQueue.Count)
        {
            Mob spawnedMob = Instantiate(mobQueue[mobsSpawned], transform.position, Quaternion.identity);
            spawnedMob.Health.OnDeath += () =>
            {
                RemainingMobs--;
            };
            mobsSpawned++;

            yield return new WaitForSeconds(cooldown);
        }
    }

}

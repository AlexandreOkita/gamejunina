using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public class WaveManager : MonoBehaviour
{
    [SerializeField] List<Spawner> spawners;
    [SerializeField] int currentWave = 1;
    [SerializeField] Mob zombiePrefab;
    [SerializeField] Mob skeletonPrefab;

    public event Action<int> WaveFinished;

    // Use this for initialization
    void Start()
    {
        var random = new System.Random();
        List<Mob> zombiesList = Enumerable.Repeat(zombiePrefab, GetZombiesQtt()).ToList();
        List<Mob> skeletonList = Enumerable.Repeat(skeletonPrefab, GetSkeletonsQtt()).ToList();

        Debug.Log(GetZombiesQtt());
        Debug.Log(GetSkeletonsQtt());

        zombiesList.AddRange(skeletonList);
        zombiesList.OrderBy(_ => random.NextDouble());

        zombiesList.ForEach(mob =>
        {
            Debug.Log(mob);
            Debug.Log(spawners.Count());
            Debug.Log(spawners.OrderBy(_ => random.NextDouble()).First());
            spawners.OrderBy(_ => random.NextDouble())
                    .First()
                    .AddMobToQueue(mob);
        });

        spawners.ForEach(spawner =>
        {
            spawner.StartSpawning();
        });
    }

    // Update is called once per frame
    void Update()
    {
        int remainingMobs = 0;
        spawners.ForEach(spawner =>
        {
            remainingMobs += spawner.RemainingMobs;
        }
        );
        if (remainingMobs <= 0)
        {
            WaveFinished?.Invoke(currentWave);
            //Debug.Log("Wave Finished!");
        }
    }

    private int GetSkeletonsQtt()
    {
        // A partir da quarta rodada, nasce 2 esqueletos extras por rodada.
        int skeletonsQtt = 2 * currentWave - 6;
        if (skeletonsQtt < 0)
        {
            return 0;
        }
        return skeletonsQtt;
    }

    private int GetZombiesQtt()
    {
        // Nasce 3 zumbis extras por rodada.
        return 3 * currentWave;
    }
}

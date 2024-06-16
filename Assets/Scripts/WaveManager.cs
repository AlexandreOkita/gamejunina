using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public class WaveManager : MonoBehaviour
{
    [SerializeField] List<Spawner> spawners;
    [SerializeField] Mob zombiePrefab;
    [SerializeField] Mob skeletonPrefab;

    private bool waveFinished = false;

    public event Action WaveFinished;

    // Use this for initialization
    public void StartWave(int currentWave)
    {
        waveFinished = false;
        var random = new System.Random();
        List<Mob> zombiesList = Enumerable.Repeat(zombiePrefab, GetZombiesQtt(currentWave)).ToList();
        List<Mob> skeletonList = Enumerable.Repeat(skeletonPrefab, GetSkeletonsQtt(currentWave)).ToList();


        zombiesList.AddRange(skeletonList);
        zombiesList.OrderBy(_ => random.NextDouble());

        zombiesList.ForEach(mob =>
        {
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
        if (remainingMobs <= 0 && !waveFinished)
        {
            waveFinished = true;
            WaveFinished?.Invoke();
            resetSpawners();
            Debug.Log("Wave Finished!");
        }
    }

    private int GetSkeletonsQtt(int currentWave)
    {
        // A partir da quarta rodada, nasce 2 esqueletos extras por rodada.
        int skeletonsQtt = 2 * currentWave - 4;
        if (skeletonsQtt < 0)
        {
            return 0;
        }
        return skeletonsQtt * GameManager.Instance.Players.Count;
    }

    private int GetZombiesQtt(int currentWave)
    {
        // Nasce 3 zumbis extras por rodada.
        return (3 * currentWave + 4) * GameManager.Instance.Players.Count;
    }

    private void resetSpawners()
    {
        spawners.ForEach(spawner =>
        {
            spawner.ResetSpawner();
        });
    }
}

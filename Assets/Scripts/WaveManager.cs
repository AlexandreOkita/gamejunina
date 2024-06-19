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
        List<MobProperties> zombiesList = GetMobQueue(3 * currentWave + 2, zombiePrefab, currentWave);
        List<MobProperties> skeletonList = GetMobQueue(2 * currentWave - 4, skeletonPrefab, currentWave);


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
            ResetSpawners();
            Debug.Log("Wave Finished!");
        }
    }

    private void ResetSpawners()
    {
        spawners.ForEach(spawner =>
        {
            spawner.ResetSpawner();
        });
    }

    private float GetHealthMod(int wave)
    {
        return (float)(1 + ((wave - 1) * 0.1));
    }

    private List<MobProperties> GetMobQueue(int baseQtt, Mob mob, int currentWave)
    {
        var mobQtt = Mathf.Max(baseQtt, 0) * GameManager.Instance.Players.Count;
        return Enumerable.Repeat(new MobProperties(mob, GetHealthMod(currentWave)), mobQtt).ToList();
    }
}

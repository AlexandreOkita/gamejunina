using System;
using System.Collections;
using Roguelike;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int startLevel = 0;
    [SerializeField] WaveManager waveManager;
    [SerializeField] UpgradesManager upgradesManager;

    public Action NewLevelStarted;

    private int currentWave;
    private bool gameStarted = false;

    static LevelManager _instance;

    public static LevelManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<LevelManager>();
            }

            return _instance;
        }

        private set
        {
            _instance = value;
        }
    }

    void Update()
    {
        if (GameManager.Instance.Players.Count > 0 && !gameStarted)
        {
            gameStarted = true;
            currentWave = startLevel;
            waveManager.WaveFinished += OnWaveFinished;
            waveManager.StartWave(currentWave);
        }
    }



    private void OnWaveFinished()
    {
        NewLevelStarted.Invoke();
        currentWave++;
        Debug.Log($"Começando próxima wave!!! - {currentWave}");
        StartCoroutine(StartNextWaveAfterDelay(5f));
        upgradesManager.ShowUpgrades();
    }

    private IEnumerator StartNextWaveAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        waveManager.StartWave(currentWave);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int startLevel = 0;
    [SerializeField] WaveManager waveManager;
    private int currentWave;
    // Start is called before the first frame update
    void Start()
    {
        currentWave = startLevel;
        waveManager.WaveFinished += OnWaveFinished;
        waveManager.StartWave(currentWave);
    }

    private void OnWaveFinished()
    {
        currentWave++;
        Debug.Log($"Começando próxima wave!!! - {currentWave}");
        StartCoroutine(StartNextWaveAfterDelay(5f));
    }

    private IEnumerator StartNextWaveAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        waveManager.StartWave(currentWave);
    }
}

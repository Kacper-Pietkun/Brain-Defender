using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WavesList))]
public class WavesManager : MonoBehaviour
{
    public void StartGame(System.Object obj, EventArgs args)
    {
        NextWave();
    }

    public void ResetCurrentGameInfo(System.Object obj, EventArgs args)
    {
        waveNumber = -1;
        if(spawningCoroutine != null)
            StopCoroutine(spawningCoroutine);
    }

    public void StopSpawningWaves(System.Object obj, EventArgs args)
    {
        if (spawningCoroutine != null)
            StopCoroutine(spawningCoroutine);
        if(pauseCoroutine != null)
            StopCoroutine(pauseCoroutine);
    }

    public void ResumeSpawningWaves(System.Object obj, EventArgs args)
    {
        pauseCoroutine = StartCoroutine(PauseBetweenSpawning());
    }



    private EnemySpawner enemySpawner;
    private Coroutine spawningCoroutine;
    private Coroutine pauseCoroutine;
    private WavesList wavesList;

    private int waveNumber;
    private int roundNumber;
    private int aliveEnemies;


    private void Awake()
    {
        wavesList = GetComponent<WavesList>();
        enemySpawner = GameObject.FindGameObjectWithTag(Tags.EnemiesSpawner).GetComponent<EnemySpawner>();
        EnemyActions.OnDied += OnEnemyDied;

        waveNumber = -1;
    }

    private void NextWave()
    {
        waveNumber++;
        roundNumber = 0;
        aliveEnemies = wavesList.waves[waveNumber].GetNumberOfAllZombies();

        if (waveNumber > 0)
            pauseCoroutine = StartCoroutine(PauseBetweenSpawning());
        else
            spawningCoroutine = StartCoroutine(SpawnWave());
    }

    private IEnumerator PauseBetweenSpawning()
    {
        yield return new WaitForSeconds(wavesList.waves[waveNumber].SpawnRoundInterval);
        spawningCoroutine = StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        while (roundNumber < wavesList.waves[waveNumber].RoundsNumber)
        {
            foreach (ZombieInfo info in wavesList.waves[waveNumber].Zombies)
            {
                for (int i = 0; i < info.SpawnRoundNumber; i++)
                    enemySpawner.SpawnEnemy(info);
            }

            roundNumber++;
            yield return new WaitForSeconds(wavesList.waves[waveNumber].SpawnRoundInterval);
        }
    }

    private void OnEnemyDied(System.Object obj, EventArgs args)
    {
        aliveEnemies--;
        if (aliveEnemies <= 0)
            NextWave();
    }
}

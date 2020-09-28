using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
    public void StartGame()
    {
        NextWave();
    }



    private EnemySpawner enemySpawner;

    private int waveNumber = 0;
    private int aliveEnemies = 0;

    // Information for given wave
    private int spawnWaveNumber = 15;
    private int spawnRoundNumber = 3;
    private float spawnRoundInterval = 6;

    // Delta descirbes how much given variable will change after one round (not wave) (round is when one set of enemies spawn during a wave)
    private int spawnWaveNumberDelta = 5;
    private int spawnRoundNumberDelta = 1;
    private float spawnRoundIntervalDelta = 0.2f;

    // Maximum and minimum values of given variables
    private int spawnWaveNumberMax = 160;
    private int spawnRoundNumberMax = 20;
    private float spawnRoundIntervalMin = 1;


    private void Awake()
    {
        enemySpawner = GameObject.FindGameObjectWithTag(Tags.EnemiesSpawner).GetComponent<EnemySpawner>();
        EnemyActions.OnDied += OnEnemyDied;
    }

    private void NextWave()
    {
        waveNumber++;
        aliveEnemies = spawnWaveNumber;
        if (waveNumber > 1)
            StartCoroutine(PauseBetweenWaves());
        else
            StartCoroutine(SpawnWave());
    }

    private IEnumerator PauseBetweenWaves()
    {
        yield return new WaitForSeconds(spawnRoundInterval);
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        int alreadySpawned = 0;

        while (true)
        {
            for (int i = 0; i < spawnRoundNumber; i++)
                enemySpawner.SpawnEnemy(2, 3, 4, 8, 1.5F);

            alreadySpawned += spawnRoundNumber;
            if (alreadySpawned >= spawnWaveNumber)
                break;

            yield return new WaitForSeconds(spawnRoundInterval);
        }
        if (spawnWaveNumber < spawnWaveNumberMax)
            spawnWaveNumber += spawnWaveNumberDelta;
        if (spawnRoundNumber < spawnRoundNumberMax)
            spawnRoundNumber += spawnRoundNumberDelta;
        if (spawnRoundInterval > spawnRoundIntervalMin)
            spawnRoundInterval -= spawnRoundIntervalDelta;
    }

    private void OnEnemyDied(System.Object obj, EventArgs args)
    {
        aliveEnemies--;
        if (aliveEnemies <= 0)
            NextWave();
    }
}

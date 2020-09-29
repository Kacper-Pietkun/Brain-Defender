using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameButtons : MonoBehaviour
{
    public void PauseButton()
    {
        waveManager.StopSpawningWaves(this, null);
        enemySpawner.PauseEnemies(this, null);
        StartCoroutine(cameraController.MoveCameraXAxis(pauseBlock.transform.position));
    }

    public void MenuButton()
    {
        cameraController.OnCameraMoved += waveManager.ResetCurrentGameInfo;
        cameraController.OnCameraMoved += enemySpawner.DestroyAllEnemies;
        StartCoroutine(cameraController.MoveCameraXAxis(mainMenuBlock.transform.position));
    }


    private GameObject mainMenuBlock;
    private GameObject pauseBlock;
    private WavesManager waveManager;
    private EnemySpawner enemySpawner;
    private CameraController cameraController;


    private void Awake()
    {
        mainMenuBlock = GameObject.FindGameObjectWithTag(Tags.MainMenuBlock);
        pauseBlock = GameObject.FindGameObjectWithTag(Tags.PauseBlock);
        cameraController = GameObject.FindGameObjectWithTag(Tags.MainCamera).GetComponent<CameraController>();
        waveManager = GameObject.FindGameObjectWithTag(Tags.WavesManager).GetComponent<WavesManager>();
        enemySpawner = GameObject.FindGameObjectWithTag(Tags.EnemiesSpawner).GetComponent<EnemySpawner>();
    }
}

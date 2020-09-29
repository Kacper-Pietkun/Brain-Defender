using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtons : MonoBehaviour
{
    public void ResumeButton()
    {
        cameraController.OnCameraMoved += waveManager.ResumeSpawningWaves;
        cameraController.OnCameraMoved += enemySpawner.UnpauseEnemies;
        StartCoroutine(cameraController.MoveCameraXAxis(brain.transform.position));
    }

    public void RestartButton()
    {
        waveManager.ResetCurrentGameInfo(this, null);
        enemySpawner.DestroyAllEnemies(this, null);
        cameraController.OnCameraMoved += waveManager.StartGame;
        StartCoroutine(cameraController.MoveCameraXAxis(brain.transform.position));
    }

    public void MenuButton()
    {
        cameraController.OnCameraMoved += waveManager.ResetCurrentGameInfo;
        cameraController.OnCameraMoved += enemySpawner.DestroyAllEnemies;
        StartCoroutine(cameraController.MoveCameraXAxis(mainMenuBlock.transform.position));
    }


    private GameObject mainMenuBlock;
    private GameObject brain;
    private WavesManager waveManager;
    private EnemySpawner enemySpawner;
    private CameraController cameraController;


    private void Awake()
    {
        cameraController = GameObject.FindGameObjectWithTag(Tags.MainCamera).GetComponent<CameraController>();
        mainMenuBlock = GameObject.FindGameObjectWithTag(Tags.MainMenuBlock);
        brain = GameObject.FindGameObjectWithTag(Tags.Brain);
        waveManager = GameObject.FindGameObjectWithTag(Tags.WavesManager).GetComponent<WavesManager>();
        enemySpawner = GameObject.FindGameObjectWithTag(Tags.EnemiesSpawner).GetComponent<EnemySpawner>();
    }
}

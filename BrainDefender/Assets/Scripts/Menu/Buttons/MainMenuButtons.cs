using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{

    public void PlayButton()
    {
        cameraController.OnCameraMoved += waveManager.StartGame;
        StartCoroutine(cameraController.MoveCameraXAxis(brain.transform.position));
    }

    public void ShopButton()
    {
        throw new NotImplementedException();
    }

    public void ExitButton()
    {
        Application.Quit();
    }


    private GameObject brain;
    private WavesManager waveManager;
    private CameraController cameraController;


    private void Awake()
    {
        cameraController = GameObject.FindGameObjectWithTag(Tags.MainCamera).GetComponent<CameraController>();
        brain = GameObject.FindGameObjectWithTag(Tags.Brain);
        waveManager = GameObject.FindGameObjectWithTag(Tags.WavesManager).GetComponent<WavesManager>();
    }
}

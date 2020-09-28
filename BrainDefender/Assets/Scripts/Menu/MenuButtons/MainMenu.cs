using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private float cameraAnimationTime;
    private GameObject mainCamera;
    private GameObject brain;
    private WavesManager waveManager;


    private void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag(Tags.MainCamera);
        brain = GameObject.FindGameObjectWithTag(Tags.Brain);
        waveManager = GameObject.FindGameObjectWithTag(Tags.WavesManager).GetComponent<WavesManager>();
    }
    public void PlayButton()
    {
        StartCoroutine(MoveCamera(mainCamera.transform.position, brain.transform.position));
    }

    // In x - axis
    private IEnumerator MoveCamera(Vector3 cameraStartPosition, Vector3 destination)
    {
        float currentTime = 0;
        while(currentTime < cameraAnimationTime)
        {
            currentTime += Time.deltaTime;
            mainCamera.transform.position = new Vector3(Mathf.Lerp(cameraStartPosition.x, destination.x, currentTime / cameraAnimationTime), cameraStartPosition.y, cameraStartPosition.z);
            yield return new WaitForEndOfFrame();
        }
        waveManager.StartGame();
    }
}

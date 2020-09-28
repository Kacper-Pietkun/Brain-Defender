using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float cameraAnimationTime;
    public event EventHandler OnCameraMoved;

    public IEnumerator MoveCameraXAxis(Vector3 destination)
    {
        Vector3 cameraStartPosition = transform.position;
        float currentTime = 0;
        while (currentTime < cameraAnimationTime)
        {
            currentTime += Time.deltaTime;
            transform.position = new Vector3(Mathf.Lerp(cameraStartPosition.x, destination.x, currentTime / cameraAnimationTime), cameraStartPosition.y, cameraStartPosition.z);
            yield return new WaitForEndOfFrame();
        }
        OnCameraMoved?.Invoke(this, EventArgs.Empty);
        OnCameraMoved = delegate { };
    }
}

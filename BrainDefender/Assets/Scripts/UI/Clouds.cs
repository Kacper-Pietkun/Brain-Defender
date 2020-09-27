using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    [SerializeField]
    private GameObject cloudStart;
    
    [SerializeField]
    private GameObject cloudEnd;

    private GameObject[] clouds;
    private float[] cloudsSpeed;

    private void Awake()
    {
        clouds = GameObject.FindGameObjectsWithTag(Tags.Cloud);
        cloudsSpeed = new float[clouds.Length];
        for (int i = 0; i < clouds.Length; i++)
            cloudsSpeed[i] = Random.Range(0.5f, 1);

    }

    private void Update()
    {
        for (int i = 0; i < clouds.Length; i++)
        {
            MoveCloud(i);
            WrapCloudsPosition(i);
        }
    }

    private void MoveCloud(int index)
    {
        clouds[index].transform.position += Vector3.right * Time.deltaTime * cloudsSpeed[index];
    }

    private void WrapCloudsPosition(int index)
    {
        if (clouds[index].transform.position.x >= cloudEnd.transform.position.x)
            clouds[index].transform.position = new Vector3(cloudStart.transform.position.x, clouds[index].transform.position.y, clouds[index].transform.position.z);
    }

}

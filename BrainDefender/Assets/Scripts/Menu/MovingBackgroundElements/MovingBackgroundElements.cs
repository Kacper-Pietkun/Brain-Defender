using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackgroundElements : MonoBehaviour
{
    [SerializeField]
    protected GameObject startPositionObject;

    [SerializeField]
    protected GameObject endPositionObject;

    protected GameObject[] objects;
    protected float[] objectsSpeed;
    protected Vector3[] objectsDirection;

    protected float minSpeed;
    protected float maxSpeed;

    protected virtual void Awake()
    {
        objectsSpeed = new float[objects.Length];
        objectsDirection = new Vector3[objects.Length];
        for (int i = 0; i < objects.Length; i++)
            objectsSpeed[i] = Random.Range(minSpeed, maxSpeed);
    }

    protected void Update()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            MoveObject(i);
            WrapObjectPosition(i);
        }
    }

    protected void MoveObject(int index)
    {
        objects[index].transform.position += objectsDirection[index] * Time.deltaTime * objectsSpeed[index];
    }

    protected void WrapObjectPosition(int index)
    {
        if (objects[index].transform.position.x >= endPositionObject.transform.position.x)
            objects[index].transform.position = new Vector3(startPositionObject.transform.position.x, objects[index].transform.position.y, objects[index].transform.position.z);
        else if (objects[index].transform.position.x <= startPositionObject.transform.position.x)
            objects[index].transform.position = new Vector3(endPositionObject.transform.position.x, objects[index].transform.position.y, objects[index].transform.position.z);
    }
}

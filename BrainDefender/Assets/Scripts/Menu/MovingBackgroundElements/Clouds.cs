using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MovingBackgroundElements
{
    protected override void Awake()
    {
        objects = GameObject.FindGameObjectsWithTag(Tags.Cloud);
        minSpeed = 0.5f;
        maxSpeed = 1f;
        base.Awake();
        for (int i = 0; i < objects.Length; i++)
            objectsDirection[i] = Vector3.right;
    }
}

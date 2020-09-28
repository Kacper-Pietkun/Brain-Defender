using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesPedestrians : MovingBackgroundElements
{
    protected override void Awake()
    {
        objects = GameObject.FindGameObjectsWithTag(Tags.ZombiePedestrian);
        minSpeed = 0.2f;
        maxSpeed = 1f;
        base.Awake();
        for (int i = 0; i < objects.Length; i++)
            objectsDirection[i] = objects[i].transform.eulerAngles.y > 90 ? Vector3.left : Vector3.right;
    }
}

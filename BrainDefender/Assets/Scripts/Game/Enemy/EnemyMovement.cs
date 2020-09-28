using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public void Move(Vector3 direction, float multiplier)
    {
        transform.position += direction * multiplier * Time.deltaTime;
    }
}

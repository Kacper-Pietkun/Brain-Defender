using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStatistics))]
public class EnemyMovement : MonoBehaviour
{
    public void Move(Vector3 direction, float multiplier)
    {
        print(direction);
        transform.position += direction * multiplier * Time.deltaTime;
    }


    private EnemyStatistics enemyStatistics;

    private void Awake()
    {
        enemyStatistics = GetComponent<EnemyStatistics>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStatistics))]
[RequireComponent(typeof(EnemyMovement))]
public class EnemyController : MonoBehaviour
{
    private EnemyMovement enemyMovement;
    private EnemyStatistics enemyStatistics;
    private GameObject brain;

    private void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyStatistics = GetComponent<EnemyStatistics>();
        brain = GameObject.FindGameObjectWithTag(Tags.Brain);
    }

    private void Update()
    {
        Vector3 distance = GetDistance();
        distance = distance.magnitude <= enemyStatistics.MinimalDistance ? Vector3.zero : distance; // We don't want enemy to come to close to the brain (for animation purpose)
        Vector3 direction = Vector3.Normalize(distance);
        enemyMovement.Move(direction, enemyStatistics.MovementSpeed);
    }

    private Vector3 GetDistance()
    {
        return brain.transform.position - transform.position;
    }
}


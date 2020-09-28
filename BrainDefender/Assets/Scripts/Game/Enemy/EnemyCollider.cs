using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStatistics))]
[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(EnemyActions))]
public class EnemyCollider : MonoBehaviour
{
    private EnemyStatistics enemyStatistics;
    private EnemyMovement enemyMovement;
    private EnemyActions enemyActions;
    private GameObject brain;


    private void Awake()
    {
        enemyStatistics = GetComponent<EnemyStatistics>();
        enemyMovement = GetComponent<EnemyMovement>();
        enemyActions = GetComponent<EnemyActions>();
        brain = GameObject.FindGameObjectWithTag(Tags.Brain);
    }

    public void OnMouseDown()
    {
        PushAwayEnemy();
        enemyActions.TakeDamage(Values.AttackDamage);
    }

    private void PushAwayEnemy()
    {
        Vector3 direction = GetDirection();
        float multiplier = Values.pushStrength / enemyStatistics.Weight;
        enemyMovement.Move(direction, multiplier);
    }

    private Vector3 GetDirection()
    {
        return Vector3.Normalize(transform.position - brain.transform.position);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStatistics))]
public class EnemyActions : MonoBehaviour
{
    public static event EventHandler OnDied;
    public event Action<float, int> OnTakenDamage;

    public void TakeDamage(int attackDamage)
    {
        enemyStatistics.HealtPoints -= attackDamage;
        OnTakenDamage?.Invoke((float)attackDamage / (float)enemyStatistics.MaxHealtPoints, enemyStatistics.HealtPoints);

        if (enemyStatistics.HealtPoints <= 0)
            Die();
    }


    private EnemyStatistics enemyStatistics;

    private void Awake()
    {
        enemyStatistics = GetComponent<EnemyStatistics>();
    }

    private void Die()
    {
        GameObject.Destroy(gameObject, 0.7f);
        OnDied?.Invoke(this, EventArgs.Empty);
        // TODO:
        // - add points to the score
    }
}

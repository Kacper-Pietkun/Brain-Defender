using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStatistics))]
[RequireComponent(typeof(BoxCollider2D))]
public class EnemyActions : MonoBehaviour
{
    public static event EventHandler OnDied;
    public event Action<float, int> OnTakenDamage;

    public void TakeDamage(int attackDamage)
    {
        enemyStatistics.HealtPoints -= attackDamage;
        OnTakenDamage?.Invoke((float)attackDamage / (float)enemyStatistics.MaxHealtPoints, enemyStatistics.HealtPoints);

        if (enemyStatistics.HealtPoints == 0)
        {
            Die();
            boxCollider2D.enabled = false;
        }
    }


    private EnemyStatistics enemyStatistics;
    private EnemySpawner enemySpawner;
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        enemyStatistics = GetComponent<EnemyStatistics>();
        enemySpawner = GameObject.FindGameObjectWithTag(Tags.EnemiesSpawner).GetComponent<EnemySpawner>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Die()
    {
        enemySpawner.AliveEnemies.Remove(gameObject);
        GameObject.Destroy(gameObject, 1f);
        OnDied?.Invoke(this, EventArgs.Empty);
        // TODO:
        // - add points to the score
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStatistics))]
[RequireComponent(typeof(EnemyAnimator))]
public class EnemyActions : MonoBehaviour
{
    public static event EventHandler OnDied;
    public event Action<float> OnTakenDamage;

    public void TakeDamage(int attackDamage)
    {
        enemyStatistics.HealtPoints -= attackDamage;
        
        if (enemyStatistics.HealtPoints <= 0)
            Die();
        else
            OnTakenDamage?.Invoke((float)attackDamage / (float)enemyStatistics.MaxHealtPoints);
    }


    private EnemyStatistics enemyStatistics;
    private EnemyAnimator enemyAnimator;

    private void Awake()
    {
        enemyStatistics = GetComponent<EnemyStatistics>();
        enemyAnimator = GetComponent<EnemyAnimator>();   
    }

    private void Die()
    {
        GameObject.Destroy(gameObject, 1.0f);
        enemyAnimator.PlayDieAnimation();
        OnDied?.Invoke(this, EventArgs.Empty);
        // OnDied event subscribers should:
        // - add points to the score
    }
}

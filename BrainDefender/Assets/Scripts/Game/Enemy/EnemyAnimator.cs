using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyActions))]
public class EnemyAnimator : MonoBehaviour
{
    private Animator animator;
    private EnemyActions enemyActions;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        enemyActions = GetComponentInChildren<EnemyActions>();
        enemyActions.OnTakenDamage += OnTakenDamage;
    }

    private void OnTakenDamage(float damagePercent, int actualHealtPoints)
    {
        if (actualHealtPoints <= 0)
            animator.SetBool("isDead", true);
        else
            StartCoroutine(PushedAwayAnimation());

    }

    private IEnumerator PushedAwayAnimation()
    {
        animator.SetBool("isPushedAway", true);
        yield return new WaitForEndOfFrame();
        animator.SetBool("isPushedAway", false);
    }
}

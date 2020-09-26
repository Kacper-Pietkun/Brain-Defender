using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public void PlayPushedAwayAnimation()
    {
        StartCoroutine(PushedAwayAnimation());
    }

    public void PlayDieAnimation()
    {
        animator.SetBool("isDead", true);
    }


    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private IEnumerator PushedAwayAnimation()
    {
        animator.SetBool("isPushedAway", true);
        yield return new WaitForEndOfFrame();
        animator.SetBool("isPushedAway", false);
    }
}

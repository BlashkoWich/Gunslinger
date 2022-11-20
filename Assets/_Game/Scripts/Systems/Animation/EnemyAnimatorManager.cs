using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorManager
{
    public event Action OnNeedAnimator;

    public Animator animator;

    private bool IsNeedAnimator()
    {
        if(animator == null)
        {
            OnNeedAnimator?.Invoke();
        }
        return true;
    }
    public void Idle()
    {
        IsNeedAnimator();
        animator.SetTrigger("IDLE");
    }
    public void Walk()
    {
        IsNeedAnimator();
        animator.SetTrigger("WALK");
    }
    public void Run()
    {
        IsNeedAnimator();
        animator.SetTrigger("RUN");
    }
    public void Attack()
    {
        IsNeedAnimator();
        animator.SetTrigger("ATTACK");
    }
}

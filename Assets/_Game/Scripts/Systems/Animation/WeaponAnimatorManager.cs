using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimatorManager
{
    public WeaponAnimatorManager(Animator animator)
    {
        _animator = animator;
    }

    private Animator _animator;

    public void Shoot()
    {
        _animator.SetTrigger("SHOOT");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualisatorWeapon : IVisualisator
{
    [SerializeField]
    private Animator _animator;
    public Animator GetAnimator => _animator;
}

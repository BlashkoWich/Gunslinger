using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualisatorCreature : IVisualisator
{
    [SerializeField]
    private Animator _animator;
    public Animator GetAnimator => _animator;
}

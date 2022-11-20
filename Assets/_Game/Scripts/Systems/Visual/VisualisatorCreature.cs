using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualisatorCreature : IVisualisator
{
    [SerializeField]
    private Animator _animator;
    public Animator GetAnimator => _animator;

    [SerializeField]
    private Rigidbody[] _ragdollRigidbodies;
    [SerializeField]
    private Collider[] _ragdollColliders;

    public void RagdollToogle(bool isActivate)
    {
        isActivate = !isActivate;
        _animator.enabled = isActivate;
        for (int i = 0; i < _ragdollRigidbodies.Length; i++)
        {
            _ragdollRigidbodies[i].isKinematic = isActivate;
            _ragdollColliders[i].enabled = !isActivate;
        }
    }
}

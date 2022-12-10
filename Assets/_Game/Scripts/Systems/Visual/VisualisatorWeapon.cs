using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualisatorWeapon : IVisualisator
{
    [SerializeField]
    private Animator _animator;
    public Animator GetAnimator => _animator;

    [SerializeField] private Transform _aimTransform;
    public Transform GetAimTransform => _aimTransform;

    [SerializeField]
    private CreatureIKTargets _creatureIKTargets;
    public CreatureIKTargets GetCreatureIKTargets => _creatureIKTargets;
}

[System.Serializable]
public class CreatureIKTargets
{
    [SerializeField]
    private HandIKTargets _leftHandIKTarget;
    [SerializeField]
    private HandIKTargets _rightHandIKTarget;

    public HandIKTargets GetLeftHandIKTarget => _leftHandIKTarget;
    public HandIKTargets GetRightHandIKTarget => _rightHandIKTarget;

    private List<Transform> GetAllIKTransforms
    {
        get
        {
            List<Transform> transforms = new List<Transform>();

            List<Transform> leftHandTransforms = GetTransformsFromHand(_leftHandIKTarget);
            List<Transform> rightHandTransforms = GetTransformsFromHand(_rightHandIKTarget);
            for (int i = 0; i < leftHandTransforms.Count; i++)
            {
                transforms.Add(leftHandTransforms[i]);
                transforms.Add(rightHandTransforms[i]);
            }

            return transforms;

            List<Transform> GetTransformsFromHand(HandIKTargets handIKTargets)
            {
                List<Transform> handTransforms = new List<Transform>();
                handTransforms.Add(handIKTargets.GetHandTarget);
                handTransforms.Add(handIKTargets.GetFingerIndex1);
                handTransforms.Add(handIKTargets.GetFingerIndex2);
                handTransforms.Add(handIKTargets.GetFingerIndex3);
                handTransforms.Add(handIKTargets.GetFingerIndex4);
                handTransforms.Add(handIKTargets.GetFingerIndex5);

                return handTransforms;
            }
        }
    }

    public void UpdateRig(CreatureIKTargets creatureIKTargets)
    {
        List<Transform> currentTransforms = GetAllIKTransforms;
        List<Transform> otherTransforms = creatureIKTargets.GetAllIKTransforms;
        for (int i = 0; i < currentTransforms.Count; i++)
        {
            currentTransforms[i].transform.SetPositionAndRotation(otherTransforms[i].transform.position, otherTransforms[i].transform.rotation);
        }
    }
}

[System.Serializable]
public class HandIKTargets
{
    [SerializeField]
    private Transform _handTarget;
    [SerializeField]
    private Transform _fingerIndex1;
    [SerializeField]
    private Transform _fingerIndex2;
    [SerializeField]
    private Transform _fingerIndex3;
    [SerializeField]
    private Transform _fingerIndex4;
    [SerializeField]
    private Transform _fingerIndex5;

    public Transform GetHandTarget => _handTarget;
    public Transform GetFingerIndex1 => _fingerIndex1;
    public Transform GetFingerIndex2 => _fingerIndex2;
    public Transform GetFingerIndex3 => _fingerIndex3;
    public Transform GetFingerIndex4 => _fingerIndex4;
    public Transform GetFingerIndex5 => _fingerIndex5;
}

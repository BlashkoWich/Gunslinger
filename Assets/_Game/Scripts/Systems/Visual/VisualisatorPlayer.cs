using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualisatorPlayer : IVisualisator
{
    [SerializeField]
    private CreatureIKTargets _creatureIKTargets;
    public CreatureIKTargets GetCreatureIKTargets => _creatureIKTargets;
}

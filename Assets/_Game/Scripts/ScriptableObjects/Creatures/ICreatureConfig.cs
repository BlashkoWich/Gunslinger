using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICreatureConfig : ScriptableObject
{
    [SerializeField]
    private IVisualisator _visualisatorPrefab;

    public IVisualisator GetVisualisatorPrefab => _visualisatorPrefab;
}
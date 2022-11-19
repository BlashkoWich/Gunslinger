using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVisualizable
{
    public VisualSystem GetVisualSystem { get; }
    public Transform GetVisualPoint { get; }
    public IVisualisator GetVisualisatorPrefab { get; }
}
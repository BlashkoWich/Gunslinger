using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualManager : MonoBehaviour
{
    private Pool _pool = new Pool();

    public void Subscribe(IVisualizable visualizable)
    {
        visualizable.GetVisualSystem.OnNeedVisual += (string name) =>
        {
            if(_pool.GetCountActivateFreeObjects(name) < 1)
            {
                _pool.AddObject(Instantiate(visualizable.GetVisualisatorPrefab));
            }
            List<IPoolable> poolables = _pool.GetFreeObjects(1, name);
            visualizable.GetVisualSystem.SetVisualisator((IVisualisator)poolables[0]);
        };
        visualizable.GetVisualSystem.OnRemoveVisualisator += (IVisualisator visualisator) =>
        {
            _pool.AddObject(visualisator);
        };
    }
}

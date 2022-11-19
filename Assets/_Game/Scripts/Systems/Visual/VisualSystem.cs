using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualSystem
{
    public VisualSystem(IVisualizable self)
    {
        _self = self;
    }

    public event Action<string> OnNeedVisual;
    public event Action<IVisualisator> OnRemoveVisualisator;

    private IVisualizable _self;

    private IVisualisator _visualisator;

    public void SpawnVisual()
    {
        if(_visualisator == null)
        {
            OnNeedVisual?.Invoke(_self.GetVisualisatorPrefab.GetName);
        }
        else if(_visualisator.name != _self.GetVisualisatorPrefab.GetName)
        {
            OnRemoveVisualisator?.Invoke(_visualisator);
            OnNeedVisual?.Invoke(_self.GetVisualisatorPrefab.GetName);
        }
    }
    public void SetVisualisator(IVisualisator visualisator)
    {
        _visualisator = visualisator;
        _visualisator.transform.position = _self.GetVisualPoint.position;
        _visualisator.transform.parent = _self.GetVisualPoint;
    }
}

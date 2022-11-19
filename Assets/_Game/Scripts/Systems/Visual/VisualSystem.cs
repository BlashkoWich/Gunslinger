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
            OnNeedVisual?.Invoke(_self.GetVisualisatorPrefab.name);
        }
        if(_visualisator.name != _self.GetVisualisatorPrefab.name)
        {
            OnRemoveVisualisator?.Invoke(_visualisator);
            OnNeedVisual?.Invoke(_self.GetVisualisatorPrefab.name);
        }
    }
    public void SetVisualisator(IVisualisator visualisator)
    {
        _visualisator = visualisator;
    }
}

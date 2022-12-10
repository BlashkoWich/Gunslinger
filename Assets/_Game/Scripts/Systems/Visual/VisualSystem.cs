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

    protected IVisualizable _self;

    public IVisualisator visualisator { get; private set; }

    public void SpawnVisual()
    {
        if(visualisator == null)
        {
            OnNeedVisual?.Invoke(_self.GetVisualisatorPrefab.GetName);
        }
        else if(visualisator.name != _self.GetVisualisatorPrefab.GetName)
        {
            OnRemoveVisualisator?.Invoke(visualisator);
            OnNeedVisual?.Invoke(_self.GetVisualisatorPrefab.GetName);
        }
    }
    public void SetVisualisator(IVisualisator visualisator)
    {
        this.visualisator = visualisator;
        this.visualisator.transform.position = _self.GetVisualPoint.position;
        this.visualisator.transform.parent = _self.GetVisualPoint;
    }
}

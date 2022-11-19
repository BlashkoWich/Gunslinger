using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VisualConfig", menuName = "Config/Game/Creature/VisualConfig", order = 1)]
public class VisualConfig : ScriptableObject
{
    private string _id;
    [SerializeField]
    private IVisualisator _visualisator;
    
    public IVisualisator GetVisualisator
    {
        get
        {
            if(_id == default)
            {
                _id = Guid.NewGuid().ToString();
            }

            return _visualisator;
        }
    }
    public string GetId
    {
        get
        {
            if (_id == default)
            {
                _id = Guid.NewGuid().ToString();
            }

            return _id;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IVisualisator : MonoBehaviour, IPoolable
{
    public event Action OnAddToPool;

    public string GetName => gameObject.name;
}

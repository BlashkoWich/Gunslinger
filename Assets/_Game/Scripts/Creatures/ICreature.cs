using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICreature : MonoBehaviour, IVisualizable
{
    protected abstract ICreatureConfig GetConfig { get; }
    #region Visual
    private VisualSystem _visualSystem;
    public VisualSystem GetVisualSystem
    {
        get
        {
            if (_visualSystem == null)
            {
                _visualSystem = new VisualSystem(this);
            }

            return _visualSystem;
        }
    }
    [SerializeField]
    private Transform _visualPoint;
    public Transform GetVisualPoint => _visualPoint;
    public IVisualisator GetVisualisatorPrefab => GetConfig.GetVisualisatorPrefab;
    #endregion

    public abstract void Initialize(ICreatureConfig creatureConfig);
}

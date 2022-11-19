using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IWeapon : MonoBehaviour, IVisualizable, IPoolable
{
    private WeaponConfig _weaponConfig;

    public WeaponStats weaponStats { get; private set; }
    #region Pool
    public event Action OnAddToPool;
    public string GetName => gameObject.name;
    #endregion
    #region Visual
    private VisualSystem _visualSystem;
    public VisualSystem GetVisualSystem
    {
        get
        {
            if(_visualSystem == null)
            {
                _visualSystem = new VisualSystem(this);
            }
            
            return _visualSystem;
        }
    }
    [SerializeField]
    private Transform _visualPoint;
    public Transform GetVisualPoint => _visualPoint;
    public IVisualisator GetVisualisatorPrefab => _weaponConfig.GetVisualisatorPrefab;
    #endregion

    public void Initialize(WeaponConfig weaponConfig)
    {
        weaponStats = weaponConfig.GetWeaponStats;
        _weaponConfig = weaponConfig;
        GetVisualSystem.SpawnVisual();
    }
}

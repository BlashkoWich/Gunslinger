using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ICreature, IHealthable, IPoolable
{
    private EnemyConfig _enemyConfig;
    protected override ICreatureConfig GetConfig => _enemyConfig;
    #region Pool
    public event Action OnAddToPool;
    public string GetName => gameObject.name;
    #endregion
    #region Health
    public HealthStats healthStats { get; set; }

    [SerializeField]
    private HealthSystem _healthSystem;

    public HealthSystem GetHealthSystem
    {
        get
        {
            if (_healthSystem == null)
            {
                _healthSystem = new HealthSystem(this);
            }

            return _healthSystem;
        }
    }
    #endregion

    public override void Initialize(ICreatureConfig creatureConfig)
    {
        _enemyConfig = creatureConfig as EnemyConfig;
        healthStats = _enemyConfig.GetHealthStats;
        GetVisualSystem.SpawnVisual();
    }
}

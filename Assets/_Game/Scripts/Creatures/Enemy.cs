using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ICreature, IHealthable, IPoolable
{
    private EnemyConfig _enemyConfig;
    protected override ICreatureConfig GetConfig => _enemyConfig;
    private VisualisatorCreature GetVisualisatorCreature => (VisualisatorCreature)GetVisualSystem.visualisator;
    [SerializeField]
    private Collider _collider;
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
                _healthSystem.OnDie += Die;
            }

            return _healthSystem;
        }
    }
    #endregion
    #region Animation
    private EnemyAnimatorManager _enemyAnimatorManager;
    private EnemyAnimatorManager GetEnemyAnimatorManager
    {
        get
        {
            if(_enemyAnimatorManager == null)
            {
                _enemyAnimatorManager = new EnemyAnimatorManager();
                _enemyAnimatorManager.OnNeedAnimator += () =>
                {
                    _enemyAnimatorManager.animator = GetVisualisatorCreature.GetAnimator;
                };
            }

            return _enemyAnimatorManager;
        }
    }
    #endregion

    public override void Initialize(ICreatureConfig creatureConfig)
    {
        _enemyConfig = creatureConfig as EnemyConfig;
        healthStats = _enemyConfig.GetHealthStats;
        GetVisualSystem.SpawnVisual();
        _collider.enabled = true;
        GetVisualisatorCreature.RagdollToogle(false);
    }

    private void Die()
    {
        _collider.enabled = false;
        GetVisualisatorCreature.RagdollToogle(true);
        StartCoroutine(TimerToHide());

        IEnumerator TimerToHide()
        {
            yield return new WaitForSeconds(5f);
            OnAddToPool?.Invoke();
            GetVisualisatorCreature.AddToPool();
        }
    }
}

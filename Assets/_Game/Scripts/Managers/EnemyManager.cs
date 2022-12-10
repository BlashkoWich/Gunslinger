using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private ManagersContainer _managersContainer;

    [SerializeField]
    private Enemy _enemyPrefab;
    [SerializeField]
    private EnemyConfig _enemyConfig;

    private Pool _pool;
    private Pool getPool
    {
        get
        {
            if(_pool == null)
            {
                _pool = new Pool();

                _pool.OnNeedObjects += (int count, System.Type type) =>
                {
                    for (int i = 0; i < count; i++)
                    {
                        Enemy enemy = Instantiate(_enemyPrefab, new Vector3(100, 100, 100), Quaternion.identity);
                        _managersContainer.GetVisualManager.Subscribe(enemy);
                        _pool.AddObject(enemy);
                    }
                };
            }
            
            return _pool;
        }
    }

    private Timer _timer;
    public Timer GetTimer
    {
        get
        {
            if (_timer == null)
            {
                _timer = new Timer();
                _timer.OnEndTimer += EndTimer;
            }

            return _timer;
        }
    }

    private LevelConfig getLevelConfig => _managersContainer.GetGameManager.GetLevelConfig;

    private void FixedUpdate()
    {
        GetTimer.UpdateTime(Time.fixedDeltaTime);
    }

    public void SpawnStartEnemies()
    {
        Transform[] enemySpawnpoints = _managersContainer.GetLevelManager.GetLevel.GetEnemySpawnpoints;

        for (int i = 0; i < enemySpawnpoints.Length; i++)
        {
            SpawnEnemy(_enemyConfig, enemySpawnpoints[i].position);
        }
    }

    private void EndTimer()
    {
        GetTimer.SetTime(getLevelConfig.GetTimeBetweenSpawnEnemy);
        SpawnNextWave();
    }
    private void SpawnNextWave()
    {
        int countEnemies = getLevelConfig.GetMaxEnemiesTogether - getPool.GetCountActivateObjects();

        Transform[] spawnPoints = _managersContainer.GetLevelManager.GetLevel.GetEnemySpawnpoints;
        List<Transform> spawnPointsList = spawnPoints.ToList();
        for (int i = 0; i < countEnemies; i++)
        {
            if (spawnPointsList.Count == 0)
            {
                spawnPointsList = spawnPoints.ToList();
            }
            int selectSpawnpoint = Random.Range(0, spawnPointsList.Count);
            SpawnEnemy(_enemyConfig, spawnPointsList[selectSpawnpoint].position);
            spawnPointsList.RemoveAt(selectSpawnpoint);
        }
    }
    private void SpawnEnemy(EnemyConfig enemyConfig, Vector3 spawnPosition)
    {
        List<IPoolable> poolables = getPool.GetFreeObjects(1);
        Enemy enemy = poolables[0] as Enemy;
        enemy.Initialize(enemyConfig);
        enemy.transform.position = spawnPosition;
    }
}

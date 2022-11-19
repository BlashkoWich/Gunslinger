using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    public void SpawnStartEnemies()
    {
        Transform[] enemySpawnpoints = _managersContainer.GetLevelManager.GetLevel.GetEnemySpawnpoints;

        for (int i = 0; i < enemySpawnpoints.Length; i++)
        {
            SpawnEnemy(_enemyConfig, enemySpawnpoints[i].position);
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

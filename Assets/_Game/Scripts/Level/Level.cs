using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]
    private Transform _playerSpawnpoint;
    [SerializeField]
    private Transform[] _enemySpawnpoints;

    public Transform GetPlayerSpawnpoint => _playerSpawnpoint;
    public Transform[] GetEnemySpawnpoints => _enemySpawnpoints;
}

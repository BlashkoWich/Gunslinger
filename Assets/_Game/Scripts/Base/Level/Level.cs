using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]
    private Transform _playerSpawnpoint;

    public Transform GetPlayerSpawnpoint => _playerSpawnpoint;
}

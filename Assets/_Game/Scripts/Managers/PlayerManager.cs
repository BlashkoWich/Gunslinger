using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private ManagersContainer _managersContainer;

    [SerializeField]
    private Player _playerPrefab;

    public Player player { get; private set; }

    public void SpawnPlayer()
    {
        Transform playerSpawnpoint = _managersContainer.GetLevelManager.GetLevel.GetPlayerSpawnpoint;
        player = Instantiate(_playerPrefab, playerSpawnpoint.position, Quaternion.identity);
        _managersContainer.GetVisualManager.Subscribe(player);
    }
}

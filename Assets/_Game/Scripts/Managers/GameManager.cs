using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private ManagersContainer _managersContainer;

    [SerializeField] private LevelConfig _levelConfig;
    public LevelConfig GetLevelConfig => _levelConfig;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Application.targetFrameRate = 60;
        _managersContainer.GetPlayerManager.SpawnPlayer();
        _managersContainer.GetEnemyManager.SpawnStartEnemies();
    }
}

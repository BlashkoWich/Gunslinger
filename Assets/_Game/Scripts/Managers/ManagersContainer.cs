using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagersContainer : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private VisualManager _visualManager;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private WeaponManager _weaponManager;
    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private ScreenManager _screenManager;
    [SerializeField] private ImpactManager _impactManager;
    [SerializeField] private CameraManager _cameraManager;

    public PlayerManager GetPlayerManager => _playerManager;
    public VisualManager GetVisualManager => _visualManager;
    public LevelManager GetLevelManager => _levelManager;
    public WeaponManager GetWeaponManager => _weaponManager;
    public EnemyManager GetEnemyManager => _enemyManager;
    public ScreenManager GetScreenManager => _screenManager;
    public ImpactManager GetImpactManager => _impactManager;
    public CameraManager GetCameraManager => _cameraManager;
    public GameManager GetGameManager => _gameManager;
}
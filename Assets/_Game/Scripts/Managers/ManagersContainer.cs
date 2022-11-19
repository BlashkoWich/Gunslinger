using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagersContainer : MonoBehaviour
{
    [SerializeField]
    private PlayerManager _playerManager;
    [SerializeField]
    private VisualManager _visualManager;
    [SerializeField]
    private LevelManager _levelManager;
    [SerializeField]
    private WeaponManager _weaponManager;

    public PlayerManager GetPlayerManager => _playerManager;
    public VisualManager GetVisualManager => _visualManager;
    public LevelManager GetLevelManager => _levelManager;
    public WeaponManager GetWeaponManager => _weaponManager;
}

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

    public PlayerManager GetPlayerManager => _playerManager;
    public VisualManager GetVisualManager => _visualManager;
    public LevelManager GetLevelManager => _levelManager;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Config/Game/Creature/PlayerConfig", order = 1)]
public class PlayerConfig : ScriptableObject
{
    [SerializeField]
    private MoveStats _moveStats;
    [SerializeField]
    private AimStats _aimStats;
    [SerializeField]
    private IVisualisator _visualisatorPrefab;

    public MoveStats GetMoveStats => _moveStats;
    public AimStats GetAimStats => _aimStats;
    public IVisualisator GetVisualisatorPrefab => _visualisatorPrefab;
}

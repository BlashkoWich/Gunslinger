using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Config/Game/Creature/PlayerConfig", order = 1)]
public class PlayerConfig : ScriptableObject
{
    [SerializeField]
    private MoveStats _moveStats;

    public MoveStats GetMoveStats => _moveStats;
}

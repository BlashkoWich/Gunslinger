using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Config/Game/Creature/PlayerConfig", order = 1)]
public class PlayerConfig : ICreatureConfig
{
    [SerializeField]
    private MoveStats _moveStats;
    [SerializeField]
    private AimStats _aimStats;
    [SerializeField]
    private HealthStats _healthStats;
    [SerializeField]
    private WeaponConfig _startWeapon;

    public MoveStats GetMoveStats => _moveStats;
    public AimStats GetAimStats => _aimStats;
    public HealthStats GetHealthStats => _healthStats;
    public WeaponConfig GetWeapon => _startWeapon;
}

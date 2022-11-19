using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Config/Game/Creature/EnemyConfig", order = 1)]
public class EnemyConfig : ICreatureConfig
{
    [SerializeField]
    private MoveStats _moveStats;
    [SerializeField]
    private AimStats _aimStats;
    [SerializeField]
    private WeaponConfig _startWeapon;
    [SerializeField]
    private HealthStats _healthStats;

    public MoveStats GetMoveStats => _moveStats;
    public AimStats GetAimStats => _aimStats;
    public WeaponConfig GetWeapon => _startWeapon;
    public HealthStats GetHealthStats => _healthStats;
}

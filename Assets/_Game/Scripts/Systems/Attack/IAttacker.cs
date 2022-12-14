using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacker
{
    public WeaponSystem GetWeaponSystem { get; }
    public IAttackSystem GetAttackSystem { get; }
    public ImpactSystem GetImpactSystem { get; }
    public bool IsPlayerTeam { get; }
    public Transform GetWeaponPoint { get; }
}
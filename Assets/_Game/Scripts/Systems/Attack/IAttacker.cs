using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacker
{
    public WeaponSystem GetWeaponSystem { get; }
    public IAttackSystem GetAttackSystem { get; }
}
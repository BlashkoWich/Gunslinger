using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem
{
    public WeaponSystem(IAttacker self)
    {
        _self = self;
    }

    public event Action<WeaponConfig> OnNeedSpawnWeapon;

    private IAttacker _self;

    public IWeapon weapon { get; private set; }

    public void ChangeWeaponSpawn(WeaponConfig weaponConfig)
    {
        OnNeedSpawnWeapon?.Invoke(weaponConfig);
    }
    public void SetWeapon(IWeapon newWeapon)
    {
        weapon = newWeapon;
        weapon.transform.position = _self.GetWeaponPoint.position;
        weapon.transform.parent = _self.GetWeaponPoint;
    }
}
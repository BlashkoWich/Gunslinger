using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IAttackSystem
{
    public abstract event Action OnShoot;
    public event Action<int> OnUpdateAmmoMagazine;
    public event Action<int> OnUpdateAmmoStorage;

    protected IAttacker _self;

    protected float _cooldown;
    
    public int ammoCurrent { get; protected set; }
    public int ammoStorage { get; private set; }

    public abstract void Attack();
    public abstract void Reload();

    public void UpdateCooldown(float time)
    {
        if(_cooldown > 0)
        {
            _cooldown -= time;
        }
    }
    protected bool IsReadyToShoot
    {
        get
        {
            if(_cooldown <= 0 && ammoCurrent > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    protected bool IsReadyToReload
    {
        get
        {
            if(ammoCurrent < _self.GetWeaponSystem.weapon.weaponStats.ammoMagazine)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    protected void RestoreCooldown()
    {
        _cooldown = _self.GetWeaponSystem.weapon.weaponStats.cooldown;
    }
    protected void MinusAmmoMagazine()
    {
        ammoCurrent--;
        OnUpdateAmmoMagazine?.Invoke(ammoCurrent);
    }
    protected void ReloadMagazine()
    {
        if(ammoStorage <= 0)
        {
            return;
        }

        int ammoMaxMagazine = _self.GetWeaponSystem.weapon.weaponStats.ammoMagazine;
        int deltaMagazine = ammoMaxMagazine - ammoCurrent;
        deltaMagazine = Mathf.Clamp(deltaMagazine, 0, ammoStorage);
        ammoCurrent += deltaMagazine;
        ammoStorage -= deltaMagazine;

        OnUpdateAmmoMagazine?.Invoke(ammoCurrent);
        OnUpdateAmmoStorage?.Invoke(ammoStorage);
    }
    public void ChangeWeapon()
    {
        WeaponStats weaponStats = _self.GetWeaponSystem.weapon.weaponStats;
        ammoCurrent = weaponStats.ammoMagazine;
        ammoStorage = weaponStats.ammoMaxStorage;
        OnUpdateAmmoMagazine?.Invoke(ammoCurrent);
        OnUpdateAmmoStorage?.Invoke(ammoStorage);
    }
}
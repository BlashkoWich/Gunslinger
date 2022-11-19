using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IAttackSystem
{
    protected IAttacker _self;

    protected float _cooldown;

    public abstract void Attack();

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
            if(_cooldown <= 0)
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
}

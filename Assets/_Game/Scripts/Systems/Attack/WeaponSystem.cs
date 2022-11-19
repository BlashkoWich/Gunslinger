using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem
{
    public WeaponSystem(IAttacker self)
    {
        _self = self;
    }

    private IAttacker _self;

    public IWeapon weapon { get; private set; }
}
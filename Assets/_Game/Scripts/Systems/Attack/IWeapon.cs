using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IWeapon : MonoBehaviour
{
    [SerializeField]
    private WeaponConfig _weaponConfig;

    public WeaponConfig GetWeaponConfig => _weaponConfig;
}

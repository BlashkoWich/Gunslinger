using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IWeapon : MonoBehaviour
{
    [SerializeField]
    private WeaponConfig _weaponConfig;

    public WeaponStats weaponStats { get; private set; }

    private void Start()
    {
        Initialize(_weaponConfig);
    }
    public void Initialize(WeaponConfig weaponConfig)
    {
        weaponStats = weaponConfig.GetWeaponStats;
    }
}

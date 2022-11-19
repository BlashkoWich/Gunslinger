using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig", menuName = "Config/Game/Creature/WeaponConfig", order = 1)]
public class WeaponConfig : ScriptableObject
{
    [SerializeField]
    private WeaponStats _weaponsStats;

    public WeaponStats GetWeaponStats => _weaponsStats;
}

[System.Serializable]
public struct WeaponStats
{
    public float damage;
    public float cooldown;
    public float ammoMagazine;
    public float ammoMaxStorage;
}
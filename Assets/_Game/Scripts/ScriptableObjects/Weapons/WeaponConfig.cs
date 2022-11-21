using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig", menuName = "Config/Game/Creature/WeaponConfig", order = 1)]
public class WeaponConfig : ScriptableObject
{
    [SerializeField]
    private WeaponStats _weaponsStats;
    [SerializeField]
    private IVisualisator _visualisatorPrefab;

    public WeaponStats GetWeaponStats => _weaponsStats;
    public IVisualisator GetVisualisatorPrefab => _visualisatorPrefab;
}

[System.Serializable]
public struct WeaponStats
{
    public float damage;
    public float cooldown;
    public int ammoMagazine;
    public int ammoMaxStorage;
}
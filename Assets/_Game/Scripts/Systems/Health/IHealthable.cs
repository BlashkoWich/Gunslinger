using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthable
{
    public HealthStats healthStats { get; set; }
    public HealthSystem GetHealthSystem { get; }
}

[System.Serializable]
public struct HealthStats
{
    public float health;
    public float maxHealth;
    public bool isPlayerTeam;
}

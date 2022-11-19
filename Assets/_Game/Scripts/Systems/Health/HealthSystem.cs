using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    public HealthSystem(IHealthable self)
    {
        _self = self;
    }

    public event Action OnChangeHP;
    public event Action OnDie;

    private IHealthable _self;
    public void TakeDamage(int damage)
    {
        if (IsDie() == true)
        {
            return;
        }

        HealthStats healthStats = _self.healthStats;
        healthStats.health -= damage;
        _self.healthStats = healthStats;

        OnChangeHP?.Invoke();

        if (IsDie() == true)
        {
            OnDie?.Invoke();
            return;
        }
    }
    public void TakeHeal(int heal)
    {
        HealthStats healthStats = _self.healthStats;
        healthStats.health += heal;
        healthStats.health = Mathf.Clamp(healthStats.health, 1, healthStats.maxHealth);
        _self.healthStats = healthStats;

        OnChangeHP?.Invoke();
    }
    public void UpgradeHealth(int newHealth, bool isChangeHP)
    {
        HealthStats healthStats = _self.healthStats;
        healthStats.maxHealth += newHealth;
        if (isChangeHP)
        {
            healthStats.health = healthStats.maxHealth;
        }
        _self.healthStats = healthStats;
        OnChangeHP?.Invoke();
    }
    public bool IsDie()
    {
        if (_self.healthStats.health <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

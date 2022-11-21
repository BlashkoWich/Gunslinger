using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactManager : MonoBehaviour
{
    private Pool _pool = new Pool();

    public void Subscribe(IAttacker attacker)
    {
        attacker.GetImpactSystem.OnNeedImpact += (string name) =>
        {
            if (_pool.GetCountActivateFreeObjects(name) < 1)
            {
                _pool.AddObject(Instantiate(attacker.GetWeaponSystem.weapon.weaponStats.impact));
            }
            List<IPoolable> poolables = _pool.GetFreeObjects(1, name);
            attacker.GetImpactSystem.AddImpact(poolables[0]);
        };
    }
}

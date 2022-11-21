using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSystem
{
    public ImpactSystem(IAttacker self)
    {
        _self = self;
    }
    public event Action<string> OnNeedImpact;

    private IAttacker _self;

    private Pool poolImpact;
    private Pool GetPoolImpact
    {
        get 
        {
            if(poolImpact == null)
            {
                poolImpact = new Pool();
                poolImpact.OnNeedObjects += (int count, Type type) =>
                {
                    for (int i = 0; i < count; i++)
                    {
                        OnNeedImpact?.Invoke(_self.GetWeaponSystem.weapon.weaponStats.impact.GetName);
                    }
                };
            }
            return poolImpact; 
        }
    }
    public void AddImpact(IPoolable poolable)
    {
        GetPoolImpact.AddObject(poolable);
    }
    public void ShootImpact(Vector3 hitPosition, Vector3 hitNormal)
    {
        Debug.Log("ShootImpact" + hitPosition);
        Collider[] colliders = Physics.OverlapSphere(hitPosition, 0.3f);
        if (colliders.Length != 0)
        {
            List<IPoolable> poolables = GetPoolImpact.GetFreeObjects(1);
            for (int i = 0; i < poolables.Count; i++)
            {
                ImpactObject impactObject = (ImpactObject)poolables[i];
                impactObject.transform.position = hitPosition + hitNormal * 0.001f;
                impactObject.transform.rotation = Quaternion.LookRotation(hitNormal, Vector3.up) * Quaternion.Euler(Vector3.zero);
                impactObject.transform.SetParent(colliders[0].transform);
                impactObject.Activate();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private ManagersContainer _managersContainer;

    [SerializeField]
    private IWeapon _weaponPrefab;

    private Pool _pool = new Pool();

    public void Subscribe(IAttacker attacker)
    {
        attacker.GetWeaponSystem.OnNeedSpawnWeapon += (WeaponConfig weaponConfig) =>
        {
            if (_pool.GetCountActivateFreeObjects() < 1)
            {
                IWeapon weapon = Instantiate(_weaponPrefab);
                _pool.AddObject(weapon);
                _managersContainer.GetVisualManager.Subscribe(weapon);
            }
            List<IPoolable> poolables = _pool.GetFreeObjects(1);
            IWeapon weaponPool = (IWeapon)poolables[0];
            weaponPool.Initialize(weaponConfig);
            attacker.GetWeaponSystem.SetWeapon(weaponPool);
        };
    }
}

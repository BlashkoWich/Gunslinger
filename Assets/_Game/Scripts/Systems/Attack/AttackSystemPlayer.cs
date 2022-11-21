using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystemPlayer : IAttackSystem
{
    public AttackSystemPlayer(IAttacker self)
    {
        _self = self;
        _camera = Camera.main;
    }
    public override event Action OnShoot;

    private Camera _camera;

    public override void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        else if(Input.GetMouseButton(0))
        {
            Shoot();
        }    

        void Shoot()
        {
            if (IsReadyToShoot)
            {
                Vector2 shootTarget = new Vector2(Screen.width / 2, Screen.height / 2);
                Ray ray = _camera.ScreenPointToRay(shootTarget);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.gameObject.TryGetComponent(out IHealthable healthable))
                    {
                        if (healthable.healthStats.isPlayerTeam != _self.IsPlayerTeam)
                        {
                            healthable.GetHealthSystem.TakeDamage(_self.GetWeaponSystem.weapon.weaponStats.damage);
                        }
                    }
                    _self.GetImpactSystem.ShootImpact(hit.point, hit.normal);
                }
                RestoreCooldown();
                MinusAmmoMagazine();

                OnShoot?.Invoke();
            }
        }
    }
    public override void Reload()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if(IsReadyToReload)
            {
                ReloadMagazine();
            }
        }
    }
}

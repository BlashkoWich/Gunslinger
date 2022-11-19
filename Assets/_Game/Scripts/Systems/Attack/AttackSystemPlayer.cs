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

    private Camera _camera;

    public override void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(IsReadyToShoot)
            {
                Vector2 shootTarget = new Vector2(Screen.width / 2, Screen.height / 2);
                Ray ray = _camera.ScreenPointToRay(shootTarget);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if(hit.collider.gameObject.TryGetComponent(out IHealthable healthable))
                    {
                        if(healthable.healthStats.isPlayerTeam != _self.IsPlayerTeam)
                        {
                            healthable.GetHealthSystem.TakeDamage(_self.GetWeaponSystem.weapon.weaponStats.damage);
                        }
                    }
                }
                Debug.DrawRay(ray.origin, ray.direction * 999f);

                RestoreCooldown();
            }
        }
    }
}

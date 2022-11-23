using UnityEngine;

public class AttackSystemPlayer : IAttackSystem
{
    public AttackSystemPlayer(IAttacker self, IAimable aimable)
    {
        _self = self;
        _aimable = aimable;
        _camera = Camera.main;
    }
    public override event System.Action OnShoot;

    private IAimable _aimable;

    private Camera _camera;

    public override void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        else if (Input.GetMouseButton(0))
        {
            Shoot();
        }

        void Shoot()
        {
            if (IsReadyToShoot)
            {
                Vector2 shootTarget = default;
                if (_aimable.GetWeaponSightController.isSightMode)
                {
                    shootTarget = new Vector2(Screen.width / 2, Screen.height / 2);
                }
                else
                {
                    float xPosition = Screen.width / 2 + Random.Range(-10, 10);
                    float yPosition = Screen.height / 2 + Random.Range(-10, 10);
                    shootTarget = new Vector2(xPosition, yPosition);
                }

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

                _self.GetWeaponSystem.weapon.GetWeaponAnimatorManager.Shoot();
                RestoreCooldown();
                MinusAmmoMagazine();

                OnShoot?.Invoke();
            }
        }
    }
    public override void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (IsReadyToReload)
            {
                ReloadMagazine();
            }
        }
    }
}

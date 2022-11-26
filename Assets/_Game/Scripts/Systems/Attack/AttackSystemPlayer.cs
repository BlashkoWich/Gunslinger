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
    private WeaponSightController _weaponSightController;

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
                Vector2 shootTarget;
                if (_aimable.GetWeaponSightController.isSightMode)
                {
                    shootTarget = new Vector2(Screen.width / 2, Screen.height / 2);
                }
                else
                {
                    float xCenter = Screen.width / 2;
                    float yCenter = Screen.height / 2;
                    float deltaX = Random.Range(0.95f, 1.05f);
                    float deltaY = Random.Range(0.95f, 1.05f);
                    float xPosition = xCenter * deltaX;
                    float yPosition = yCenter * deltaY;
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
                    else
                    {
                        _self.GetImpactSystem.ShootImpact(hit.point, hit.normal);
                    }
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

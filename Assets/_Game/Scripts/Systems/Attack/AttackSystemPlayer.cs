using UnityEngine;
using static UnityEngine.Screen;

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
                if (_aimable.GetWeaponSightController.isSightMode)
                {
                    Transform visualisatorGetAimTransform = _self.GetWeaponSystem.weapon.GetVisualisator.GetAimTransform;
                    Vector3 startSightRay = visualisatorGetAimTransform.position;
                    Vector3 directionSightRay = -visualisatorGetAimTransform.forward;
                    Ray raySight = new Ray(startSightRay, directionSightRay);
                    Debug.DrawRay(raySight.origin, raySight.direction, Color.red);
                    RayShoot(raySight);
                }
                else
                {
                    float xCenter = width / 2;
                    float yCenter = height / 2;
                    float deltaX = Random.Range(0.95f, 1.05f);
                    float deltaY = Random.Range(0.95f, 1.05f);
                    float xPosition = xCenter * deltaX;
                    float yPosition = yCenter * deltaY;
                    Vector2 shootTarget = new Vector2(xPosition, yPosition);
                    Ray rayHitMode = _camera.ScreenPointToRay(shootTarget);
                    RayShoot(rayHitMode);
                }

                

                _self.GetWeaponSystem.weapon.GetWeaponAnimatorManager.Shoot();
                RestoreCooldown();
                MinusAmmoMagazine();

                OnShoot?.Invoke();

                void RayShoot(Ray ray)
                {
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
                }
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

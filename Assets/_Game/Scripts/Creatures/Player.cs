using UnityEngine;

public class Player : ICreature, IMovable, IAimable, IAttacker, IHealthable
{
    [SerializeField]
    private PlayerConfig _playerConfig;
    protected override ICreatureConfig GetConfig => _playerConfig;

    #region Move
    [SerializeField]
    private Rigidbody _rigidbody;
    public Rigidbody GetRigidbody => _rigidbody;

    public MoveStats moveStats { get; set; }

    private MoveSystemPlayer _moveSystemPlayer;
    public IMoveSystem GetMoveSystem
    {
        get
        {
            if (_moveSystemPlayer == null)
            {
                _moveSystemPlayer = new MoveSystemPlayer(this, _aimTransform);
            }

            return _moveSystemPlayer;
        }
    }
    #endregion
    #region Aim
    [SerializeField]
    private Transform _aimTransform;
    public Transform GetAimTransform => _aimTransform;

    private AimSystemPlayer _aimSystemPlayer;
    public IAimSystem GetAimSystem
    {
        get
        {
            if (_aimSystemPlayer == null)
            {
                _aimSystemPlayer = new AimSystemPlayer(this, this);
            }

            return _aimSystemPlayer;
        }
    }
    public AimStats GetAimStats => _playerConfig.GetAimStats;
    [SerializeField]
    private Transform _targetWeaponPosition;
    private WeaponSightController _weaponSightController;
    public WeaponSightController GetWeaponSightController
    {
        get
        {
            if(_weaponSightController == null)
            {
                _weaponSightController = new WeaponSightController();
            }

            return _weaponSightController;
        }
    }
    #endregion
    #region Attack
    private WeaponSystem _weaponSystem;
    public WeaponSystem GetWeaponSystem
    {
        get
        {
            if (_weaponSystem == null)
            {
                _weaponSystem = new WeaponSystem(this);
            }

            return _weaponSystem;
        }
    }
    private AttackSystemPlayer _attackSystemPlayer;
    public IAttackSystem GetAttackSystem
    {
        get
        {
            if (_attackSystemPlayer == null)
            {
                _attackSystemPlayer = new AttackSystemPlayer(this, this);
            }

            return _attackSystemPlayer;
        }
    }
    private ImpactSystem _impactSystem;
    public ImpactSystem GetImpactSystem
    {
        get
        {
            if (_impactSystem == null)
            {
                _impactSystem = new ImpactSystem(this);
            }

            return _impactSystem;
        }
    }
    public bool IsPlayerTeam => healthStats.isPlayerTeam;
    [SerializeField]
    private Transform _weaponPoint;
    public Transform GetWeaponPoint => _weaponPoint;
    #endregion
    #region Health
    public HealthStats healthStats { get; set; }

    [SerializeField]
    private HealthSystem _healthSystem;
    public HealthSystem GetHealthSystem
    {
        get
        {
            if (_healthSystem == null)
            {
                _healthSystem = new HealthSystem(this);
                _healthSystem.OnDie += Die;
            }

            return _healthSystem;
        }
    }
    #endregion

    private void Start()
    {
        Initialize(_playerConfig);
    }

    public override void Initialize(ICreatureConfig creatureConfig)
    {
        PlayerConfig playerConfig = (PlayerConfig)creatureConfig;
        moveStats = playerConfig.GetMoveStats;
        GetVisualSystem.SpawnVisual();
        healthStats = playerConfig.GetHealthStats;
        GetWeaponSystem.ChangeWeaponSpawn(playerConfig.GetWeapon);
    }

    private void Update()
    {
        GetMoveSystem.CalculateDirection();

        GetWeaponSightController.UpdateSightMode();

        GetAttackSystem.UpdateCooldown(Time.deltaTime);
        GetAttackSystem.Attack();
        GetAttackSystem.Reload();

        GetAimSystem.CalculateAim();
        GetAimSystem.UpdateAim();

        _weaponPoint.position = Vector3.Lerp(_weaponPoint.position, _targetWeaponPosition.position, 12 * Time.deltaTime);
        _weaponPoint.rotation = _targetWeaponPosition.rotation;
    }
    private void FixedUpdate()
    {
        GetMoveSystem.Move();
    }

    private void Die()
    {

    }
}
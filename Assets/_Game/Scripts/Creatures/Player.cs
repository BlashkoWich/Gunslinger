using System.Collections;
using System.Collections.Generic;
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
            if(_moveSystemPlayer == null)
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
            if(_aimSystemPlayer == null)
            {
                _aimSystemPlayer = new AimSystemPlayer(this);
            }

            return _aimSystemPlayer;
        }
    }
    public AimStats GetAimStats => _playerConfig.GetAimStats;
    [SerializeField]
    private Transform _targetWeaponPosition;
    #endregion
    #region Attack
    private WeaponSystem _weaponSystem;
    public WeaponSystem GetWeaponSystem
    {
        get
        {
            if(_weaponSystem == null)
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
            if(_attackSystemPlayer == null)
            {
                _attackSystemPlayer = new AttackSystemPlayer(this);
            }

            return _attackSystemPlayer;
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
            if(_healthSystem == null)
            {
                _healthSystem = new HealthSystem(this);
            }

            return _healthSystem;
        }
    }
    #endregion

    [SerializeField]
    private bool _isDebug;

    private void Awake()
    {
        GetHealthSystem.OnDie += Die;
    }
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
        if (_isDebug == false)
        {
            GetAimSystem.CalculateAim();
            GetAimSystem.UpdateAim();
        }

        GetAttackSystem.UpdateCooldown(Time.deltaTime);
        GetAttackSystem.Attack();
        GetAttackSystem.Reload();

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
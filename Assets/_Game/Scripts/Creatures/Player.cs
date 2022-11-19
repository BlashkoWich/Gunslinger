using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IMovable, IAimable, IAttacker, IVisualizable, IHealthable
{
    [SerializeField]
    private PlayerConfig _playerConfig;

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
    #endregion
    #region Visual
    private VisualSystem _visualSystem;
    public VisualSystem GetVisualSystem
    {
        get
        {
            if(_visualSystem == null)
            {
                _visualSystem = new VisualSystem(this);
            }

            return _visualSystem;
        }
    }
    [SerializeField]
    private Transform _visualPoint;
    public Transform GetVisualPoint => _visualPoint;
    public IVisualisator GetVisualisatorPrefab => _playerConfig.GetVisualisatorPrefab;
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

    private void Awake()
    {
        GetHealthSystem.OnDie += Die;
    }
    private void Start()
    {
        Initialize(_playerConfig);
    }

    public void Initialize(PlayerConfig playerConfig)
    {
        moveStats = playerConfig.GetMoveStats;
        GetVisualSystem.SpawnVisual();
        healthStats = playerConfig.GetHealthStats;
    }

    private void Update()
    {
        GetMoveSystem.CalculateDirection();
        
        GetAimSystem.CalculateAim();
        GetAimSystem.UpdateAim();

        GetAttackSystem.UpdateCooldown(Time.deltaTime);
        GetAttackSystem.Attack();
    }
    private void FixedUpdate()
    {
        GetMoveSystem.Move();
    }

    private void Die()
    {

    }
}
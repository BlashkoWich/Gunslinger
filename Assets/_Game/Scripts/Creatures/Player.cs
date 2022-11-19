using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IMovable, IAimable
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

    private void Start()
    {
        Initialize(_playerConfig);
    }

    public void Initialize(PlayerConfig playerConfig)
    {
        moveStats = playerConfig.GetMoveStats;
    }

    private void Update()
    {
        GetMoveSystem.CalculateDirection();
        GetAimSystem.CalculateAim();
        GetAimSystem.UpdateAim();
    }
    private void FixedUpdate()
    {
        GetMoveSystem.Move();
    }
}
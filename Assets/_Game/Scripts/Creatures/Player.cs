using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IMovable
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
                _moveSystemPlayer = new MoveSystemPlayer(this);
            }

            return _moveSystemPlayer;
        }
    }
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
    }
    private void FixedUpdate()
    {
        GetMoveSystem.Move();
    }
}
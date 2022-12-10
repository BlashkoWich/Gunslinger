using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponOnPlayerMove
{
    [SerializeField]
    private Player _player;

    [SerializeField]
    private Transform _defaultTargetWeaponPosition;
    [SerializeField]
    private Transform _sightModeTargetWeaponPosition;
    [SerializeField]
    private Transform _sprintTargetWeaponPosition;
    private float _sprintWeaponStep;
    [SerializeField]
    private Transform _startSprintWeaponPosition;
    [SerializeField]
    private Transform _endSprintWeaponPosition;

    private float _speed = 1;

    private bool _isWayToStart;

    public void WeaponMove()
    {
        if (((MoveSystemPlayer) _player.GetMoveSystem).isSprint && _player.GetMoveSystem.isMoving)
        {
            if (_isWayToStart == false)
            {
                _sprintWeaponStep += _speed * Time.deltaTime;
                if(_sprintWeaponStep > 1)
                {
                    _isWayToStart = true;
                    _sprintWeaponStep = 1;
                }
            }
            else
            {
                _sprintWeaponStep -= _speed * Time.deltaTime;
                if(_sprintWeaponStep < 0)
                {
                    _isWayToStart = false;
                    _sprintWeaponStep = 0;
                }
            }
            _sprintTargetWeaponPosition.position = Vector3.Lerp(_startSprintWeaponPosition.position, _endSprintWeaponPosition.position, _sprintWeaponStep);
            _sprintTargetWeaponPosition.rotation = Quaternion.Lerp(_startSprintWeaponPosition.rotation, _endSprintWeaponPosition.rotation, _sprintWeaponStep);
            _player.GetWeaponPoint.position = _sprintTargetWeaponPosition.position;
            _player.GetWeaponPoint.rotation = _sprintTargetWeaponPosition.rotation;
        }
        else
        {
            if (_player.GetWeaponSightController.isSightMode)
            {
                _player.GetWeaponPoint.position = _sightModeTargetWeaponPosition.position;
                _player.GetWeaponPoint.rotation = _sightModeTargetWeaponPosition.rotation;
            }
            else
            {
                _player.GetWeaponPoint.position = Vector3.Lerp(_player.GetWeaponPoint.position, _defaultTargetWeaponPosition.position, 24 * Time.deltaTime);
                _player.GetWeaponPoint.rotation = _defaultTargetWeaponPosition.rotation;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilSystem
{
    public RecoilSystem(IAttacker attacker, IAimable aimable)
    {
        _attacker = attacker;
        _aimable = aimable;

        _attacker.GetAttackSystem.OnShoot += Recoil;
    }

    public event System.Action OnResetRecoil;

    private IAttacker _attacker;
    private IAimable _aimable;

    private const float _timeToResetRecoil = 1;
    private float _currentTimeToResetRecoil;
    private int _recoilStep;

    public void GoToResetRecoil(float deltaTime)
    {
        if(_currentTimeToResetRecoil <= 0)
        {
            return;
        }

        _currentTimeToResetRecoil -= deltaTime;

        if(_currentTimeToResetRecoil <= 0)
        {
            _recoilStep = 0;
            OnResetRecoil?.Invoke();
        }
    }

    private void Recoil()
    {
        if(_aimable.GetWeaponSightController.isSightMode == false)
        {
            _currentTimeToResetRecoil = _timeToResetRecoil;
            _recoilStep++;
            return;
        }
        if(_recoilStep >= _attacker.GetWeaponSystem.weapon.weaponStats.recoilStats.Length)
        {
            _recoilStep = 0;
        }
        float xRecoil = _attacker.GetWeaponSystem.weapon.weaponStats.recoilStats[_recoilStep].xRecoil;
        float yRecoil = _attacker.GetWeaponSystem.weapon.weaponStats.recoilStats[_recoilStep].yRecoil;

        _aimable.GetAimSystem.directionAim += new Vector3(xRecoil, yRecoil, 0);

        _recoilStep++;
        _currentTimeToResetRecoil = _timeToResetRecoil;
    }
}

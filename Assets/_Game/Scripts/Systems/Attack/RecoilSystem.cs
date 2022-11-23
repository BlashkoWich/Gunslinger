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
        }
    }

    private void Recoil()
    {
        if(_aimable.GetWeaponSightController.isSightMode == false)
        {
            return;
        }
        Debug.Log("Recoil" + _aimable.GetWeaponSightController.isSightMode);
        float xRecoil = _attacker.GetWeaponSystem.weapon.weaponStats.recoilStats[_recoilStep].xRecoil;
        float yRecoil = _attacker.GetWeaponSystem.weapon.weaponStats.recoilStats[_recoilStep].yRecoil;

        _aimable.GetAimSystem.directionAim += new Vector3(xRecoil, yRecoil, 0);

        _recoilStep++;
        _currentTimeToResetRecoil = _timeToResetRecoil;
    }
}

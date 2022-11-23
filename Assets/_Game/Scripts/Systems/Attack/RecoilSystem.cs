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

    private void Recoil()
    {
        float deltaXRecoil = _attacker.GetWeaponSystem.weapon.weaponStats.xRecoil;
        float xRecoil = Random.Range(-deltaXRecoil, deltaXRecoil);
        float deltaYRecoil = _attacker.GetWeaponSystem.weapon.weaponStats.yRecoil;
        float yRecoil = Random.Range(-deltaYRecoil, deltaYRecoil);

        _aimable.GetAimSystem.directionAim += new Vector3(xRecoil, yRecoil, 0);
    }
}

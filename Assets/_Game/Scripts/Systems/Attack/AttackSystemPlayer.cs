using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystemPlayer : IAttackSystem
{
    public AttackSystemPlayer(IAttacker self)
    {
        _self = self;
    }

    public override void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(IsReadyToShoot)
            {

            }
        }
    }
}

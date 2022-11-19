using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystemPlayer : IAttackSystem
{
    public AttackSystemPlayer(IAttacker self)
    {
        _self = self;
    }

    private IAttacker _self;

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }
}

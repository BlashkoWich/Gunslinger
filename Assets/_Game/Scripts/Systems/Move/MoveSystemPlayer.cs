using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystemPlayer : IMoveSystem
{
    public MoveSystemPlayer(IMovable self)
    {
        _self = self;
    }

    private Vector3 _direction;

    public override void CalculateDirection()
    {
        float directionX = Input.GetAxis("Horizontal");
        float directionZ = Input.GetAxis("Vertical");

        _direction = new Vector3(directionX, _self.GetRigidbody.velocity.y, directionZ);
    }

    public override void Move()
    {
        _self.GetRigidbody.velocity = _direction;
    }
}

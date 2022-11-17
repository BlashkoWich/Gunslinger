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
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Transform transform = _self.GetRigidbody.transform;
        Vector3 directionForward = transform.forward * inputZ;
        Vector3 directionRight = transform.right * inputX;
        
        _direction = (directionForward + directionRight).normalized;
    }

    public override void Move()
    {
        _self.GetRigidbody.velocity = _direction * _self.moveStats.speed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IMoveSystem
{
    protected IMovable _self;

    public bool isMoving { get; protected set; }

    public abstract void CalculateDirection();
    public abstract void Move();
}

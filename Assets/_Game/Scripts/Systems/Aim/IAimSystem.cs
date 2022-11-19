using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IAimSystem
{
    protected IAimable _self;

    public abstract void CalculateAim();
    public abstract void UpdateAim();
}
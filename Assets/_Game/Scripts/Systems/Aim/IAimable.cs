using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAimable
{
    public Transform GetAimTransform { get; }
    public IAimSystem GetAimSystem { get; }
    public AimStats GetAimStats { get; }
}

[System.Serializable]
public class AimStats
{
    public float CamSensX;
    public float CamSensY;
}
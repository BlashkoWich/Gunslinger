using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    public Rigidbody GetRigidbody { get; }
    public MoveStats moveStats { get; set; }
    public IMoveSystem GetMoveSystem { get; }
}

[System.Serializable]
public struct MoveStats
{
    public float speed;
}

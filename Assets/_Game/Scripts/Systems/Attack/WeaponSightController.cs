using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSightController
{
    public bool isSightMode { get; private set; }

    public void UpdateSightMode()
    {
        if(Input.GetMouseButtonDown(1))
        {
            isSightMode = true;
        }
        else if(Input.GetMouseButtonUp(1))
        {
            isSightMode = false;
        }
    }
}

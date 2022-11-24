using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSightController
{
    public event System.Action OnActivatSightMode;
    public event System.Action OnDisactivatSightMode;

    public bool isSightMode { get; private set; }

    public void UpdateSightMode()
    {
        if(Input.GetMouseButtonDown(1))
        {
            isSightMode = true;
            OnActivatSightMode?.Invoke();
        }
        else if(Input.GetMouseButtonUp(1))
        {
            isSightMode = false;
            OnDisactivatSightMode?.Invoke();
        }
    }
}

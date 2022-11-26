using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSightController
{
    public event System.Action OnActivateSightMode;
    public event System.Action OnDisactivateSightMode;

    public bool isSightMode { get; private set; }

    public void UpdateSightMode()
    {
        if(Input.GetMouseButtonDown(1))
        {
            isSightMode = true;
            OnActivateSightMode?.Invoke();
        }
        else if(Input.GetMouseButtonUp(1))
        {
            isSightMode = false;
            OnDisactivateSightMode?.Invoke();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScreen : UIScreen
{
    [SerializeField]
    private AmmoUI _ammoUI;
    [SerializeField]
    private CrosshairUI _crosshairUI;

    public AmmoUI GetAmmoUI => _ammoUI;
    public CrosshairUI GetCrosshairUI => _crosshairUI;

    private void Update()
    {
        GetCrosshairUI.Update();
    }
}
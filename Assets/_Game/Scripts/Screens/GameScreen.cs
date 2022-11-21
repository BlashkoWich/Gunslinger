using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScreen : UIScreen
{
    [SerializeField]
    private AmmoUI _ammoUI;

    public AmmoUI GetAmmoUI => _ammoUI;
}

[System.Serializable]
public class AmmoUI
{
    [SerializeField]
    private TextMeshProUGUI _ammoCurrentTMPro;
    [SerializeField]
    private TextMeshProUGUI _ammoFullTMPro;

    public void UpdateAmmoCurrent(int value)
    {
        _ammoCurrentTMPro.text = value.ToString();
    }
    public void UpdateAmmoFull(int value)
    {
        _ammoFullTMPro.text = value.ToString();
    }
}
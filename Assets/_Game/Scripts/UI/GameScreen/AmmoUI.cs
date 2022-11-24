using TMPro;
using UnityEngine;

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

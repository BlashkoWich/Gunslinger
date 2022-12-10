using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualSystemPlayer : VisualSystem
{
    public VisualSystemPlayer(IVisualizable self) : base(self)
    {
    }

    private VisualisatorPlayer GetVisualisatorPlayer => visualisator as VisualisatorPlayer;

    private WeaponSystem _weaponSystem;
    public void SetWeaponSystem(WeaponSystem weaponSystem)
    {
        _weaponSystem = weaponSystem;
    }

    public void UpdateRig()
    {
        GetVisualisatorPlayer.GetCreatureIKTargets.UpdateRig((_weaponSystem.weapon.GetVisualSystem.visualisator as VisualisatorWeapon).GetCreatureIKTargets);
    }
}

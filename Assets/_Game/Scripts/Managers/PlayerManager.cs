using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private ManagersContainer _managersContainer;

    [SerializeField]
    private Player _playerPrefab;

    public Player player { get; private set; }

    public void SpawnPlayer()
    {
        Transform playerSpawnpoint = _managersContainer.GetLevelManager.GetLevel.GetPlayerSpawnpoint;
        player = Instantiate(_playerPrefab, playerSpawnpoint.position, Quaternion.identity);
        _managersContainer.GetVisualManager.Subscribe(player);
        _managersContainer.GetWeaponManager.Subscribe(player);
        _managersContainer.GetImpactManager.Subscribe(player);

        Prepare();
        Subscribe();

        void Prepare()
        {
            for (int i = 0; i < player.GetCameraGames.Length; i++)
            {
                _managersContainer.GetCameraManager.AddCamera(player.GetCameraGames[i]);
            }
            _managersContainer.GetCameraManager.ActivateCamera(CameraType.Hip);
        }
        void Subscribe()
        {
            GameScreen gameScreen = _managersContainer.GetScreenManager.GetScreen<GameScreen>();
            AmmoUI ammoUI = gameScreen.GetAmmoUI;
            player.GetAttackSystem.OnUpdateAmmoMagazine += (int value) =>
            {
                ammoUI.UpdateAmmoCurrent(value);
            };
            player.GetAttackSystem.OnUpdateAmmoStorage += (int value) =>
            {
                ammoUI.UpdateAmmoFull(value);
            };
            CrosshairUI crosshairUI = _managersContainer.GetScreenManager.GetScreen<GameScreen>().GetCrosshairUI;
            AimSystemPlayer aimSystemPlayer = (AimSystemPlayer)player.GetAimSystem;
            aimSystemPlayer.recoilSystem.OnResetRecoil += () =>
            {
                crosshairUI.ResetScale();
            };
            player.GetAttackSystem.OnShoot += () =>
            {
                crosshairUI.IncreaseScale();
            };
            player.GetWeaponSightController.OnActivateSightMode += () =>
            {
                crosshairUI.Toogle(false);
                _managersContainer.GetCameraManager.ActivateCamera(CameraType.Sight);
            };
            player.GetWeaponSightController.OnDisactivateSightMode += () =>
            {
                crosshairUI.Toogle(true);
                _managersContainer.GetCameraManager.ActivateCamera(CameraType.Hip);
            };
        }
    }
}

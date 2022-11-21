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
        Subscribe();

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
        }
    }
}

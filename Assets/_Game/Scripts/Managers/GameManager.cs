using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private ManagersContainer _managersContainer;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _managersContainer.GetPlayerManager.SpawnPlayer();
    }
}

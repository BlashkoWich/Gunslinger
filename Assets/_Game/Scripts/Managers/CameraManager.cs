using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private Camera _mainCamera;
    public Camera GetMainCamera => _mainCamera;

    [SerializeField]
    private List<CameraGame> _cameraGames;
    public CameraGame CameraCurrent
    {
        get
        {
            for (int i = 0; i < _cameraGames.Count; i++)
            {
                if(_cameraGames[i].GetCinemachine.isActiveAndEnabled)
                {
                    return _cameraGames[i];
                }
            }
            return null;
        }
    }

    private Coroutine _shootCoroutine;

    public void SetFollower(Transform follow)
    {
        for (int i = 0; i < _cameraGames.Count; i++)
        {
            _cameraGames[i].GetCinemachine.m_Follow = follow;
            _cameraGames[i].GetCinemachine.m_LookAt = follow;
        }
    }

    public void ActivateCamera(CameraType cameraType, Transform follow = null)
    {
        for (int i = 0; i < _cameraGames.Count; i++)
        {
            _cameraGames[i].GetCinemachine.enabled = _cameraGames[i].GetCameraType == cameraType;
        }
    }
    public void AddCamera(CameraGame cameraGame)
    {
        cameraGame.GetCinemachine.enabled = false;
        _cameraGames.Add(cameraGame);
    }
}

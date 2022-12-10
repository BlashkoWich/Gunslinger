using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraGame : MonoBehaviour
{
    [SerializeField]
    private CameraType _cameraType;
    public CameraType GetCameraType => _cameraType;
    [SerializeField]
    private CinemachineVirtualCamera _cinemachine;
    public CinemachineVirtualCamera GetCinemachine => _cinemachine;
}
public enum CameraType
{
    Hip,
    Sight
}
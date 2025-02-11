using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class CameraAimChanger : MonoBehaviour
{
    public CinemachineVirtualCamera[] cameras;

    public CinemachineVirtualCamera mainCamera;
    public CinemachineVirtualCamera aimCamera;


    public CinemachineVirtualCamera startCamera;
    public CinemachineVirtualCamera currentCamera;


    void Start()
    {
        currentCamera = startCamera;

        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] == currentCamera)
            {
                cameras[i].Priority = 20;
            }
            else
            {
                cameras[i].Priority = 10;
            }
        }
    }

    public void SwitchCamera(CinemachineVirtualCamera newCamera)
    {
        currentCamera = newCamera;

        currentCamera.Priority = 20;

        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] != currentCamera)
            {
                cameras[i].Priority = 10;
            }
        }
    }
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            SwitchCamera(aimCamera);
        }
        else
        {
            SwitchCamera(mainCamera);
        }
    }
}

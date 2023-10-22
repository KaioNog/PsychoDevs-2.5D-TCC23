using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
  private CameraFollow cameraFollow;

    private float zoomedFOV = 40f; // FOV desejado quando o zoom é ativado

    void Start()
    {
        cameraFollow = GetComponent<CameraFollow>();
    }

    public void ActivateZoom()
    {
        cameraFollow.ChangeFOV(zoomedFOV); // Assume que você tem um método ChangeFOV em CameraFollow
        Debug.Log("Deu zoom");
    }

    public void DeactivateZoom()
    {
        cameraFollow.ResetFOV(); // Assume que você tem um método ResetFOV em CameraFollow para redefinir o FOV para o valor inicial
    }
}

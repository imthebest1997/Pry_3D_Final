using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineController : MonoBehaviour
{
    public CinemachineFreeLook cinemachineFreeLook;
    void Update()
    {
        if(PlayerController.instance != null)
        {
            GameObject cameraTarget = GameObject.Find("Camera Target");
//            Transform cameraTargetTransform = cameraTarget.GetComponent<Transform>();

            cinemachineFreeLook.Follow = PlayerController.instance.transform;
            cinemachineFreeLook.LookAt = cameraTarget.transform;
        }       
    }
}

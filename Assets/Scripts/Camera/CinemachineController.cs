using Cinemachine;
using Photon.Pun;
using UnityEngine;

public class CinemachineController : MonoBehaviour
{
    public CinemachineFreeLook cinemachineFreeLook;
    public bool isFollowingPlayer;
    void Update()
    {
        if(PlayerController.instance != null && !isFollowingPlayer)
        {
                isFollowingPlayer = true;
                GameObject cameraTarget = GameObject.Find("Camera Target");

                cinemachineFreeLook.Follow = PlayerController.instance.transform;
                cinemachineFreeLook.LookAt = cameraTarget.transform;
        }       
    }
}

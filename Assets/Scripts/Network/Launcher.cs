using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Launcher : MonoBehaviourPunCallbacks
{

    [SerializeField] PhotonView photonPrefab;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room");
        PhotonNetwork.Instantiate(photonPrefab.name, Vector3.zero, Quaternion.identity);
    }
}

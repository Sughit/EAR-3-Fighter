using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public GameObject player;
    public GameObject weaponManager;
    [Space]
    public Transform spawnPoint;
    [Space]
    public GameObject roomCam;
    bool playerJoined;
    public static string roomCode = "test";
    
    
    void Start()
    {
        GameObject _weaponManager = PhotonNetwork.Instantiate(weaponManager.name, Vector3.zero, Quaternion.identity);
        Debug.Log("You joined "+ PhotonNetwork.CurrentRoom.Name);
    }


}

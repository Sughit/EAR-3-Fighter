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
    public string nume = "1v1";
    
    
    void Start()
    {
        GameObject _weaponManager = Instantiate(weaponManager, Vector3.zero, Quaternion.identity);
        // GameObject _player = PhotonNetwork.Instantiate(player.name,Vector3.zero, Quaternion.identity);
        // _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        Debug.Log("You joined "+ PhotonNetwork.CurrentRoom.Name);   
    }


}

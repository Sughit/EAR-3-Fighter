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
    bool playerJoined;
    public static string roomCode = "test";
    
    void Start()
    {
        Debug.Log("Conecting...");

        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        Debug.Log("Connected to server");

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        PhotonNetwork.JoinOrCreateRoom(roomCode, null, null);

        Debug.Log("We're connected and in a room now");

        StartCoroutine(WaitToJoinARoom());
    }

    IEnumerator SpawnPlayer()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("The player will spawn soon");
        GameObject _weaponManager = PhotonNetwork.Instantiate(weaponManager.name, Vector3.zero, Quaternion.identity);
        Debug.Log("You joined "+ PhotonNetwork.CurrentRoom.Name);
    }

    IEnumerator WaitToJoinARoom()
    {
        while(!playerJoined)
        {
            if(PhotonNetwork.InRoom) 
            {
                playerJoined=true;
                Debug.Log("The player can spawn");
                StartCoroutine(SpawnPlayer());
                yield return null;
            }
            else yield return new WaitForSeconds(.2f);
        }
    }
}

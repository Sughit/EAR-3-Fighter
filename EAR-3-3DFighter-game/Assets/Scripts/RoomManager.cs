using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public GameObject player;
    [Space]
    public Transform spawnPoint;
    bool playerJoined;
    
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

        PhotonNetwork.JoinOrCreateRoom("test", null, null);

        Debug.Log("We're connected and in a room now");

        StartCoroutine(WaitToJoinARoom());
    }

    IEnumerator SpawnPlayer()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("The player will spawn soon");
        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
        _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        
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

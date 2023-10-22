using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public GameObject weaponManager;
    WeaponManager weaponManagerScript;
    [Space]
    public static string roomCode = "test";
    public string nume = "1v1";
    public static RoomManager instance;
    [Space]
    public static int masterID;
    public static int clientID;
    
    void Awake()
    {
        instance=this;
    }

    void Start()
    {
        weaponManagerScript=weaponManager.GetComponent<WeaponManager>();
        GameObject _weaponManager = Instantiate(weaponManager, Vector3.zero, Quaternion.identity);
        // GameObject _player = PhotonNetwork.Instantiate(player.name,Vector3.zero, Quaternion.identity);
        // _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        Debug.Log("You joined "+ PhotonNetwork.CurrentRoom.Name);   
    }
    public void RespawnPlayer()
    {
        
        if(PhotonNetwork.IsMasterClient)
        {
            switch(WeaponManager.masterPlayer)
            {
                case "sword":
                weaponManagerScript.SpawnPlayer(weaponManagerScript.swordP,weaponManagerScript.masterSpawnPoint);
                break;
                case "spear":
                weaponManagerScript.SpawnPlayer(weaponManagerScript.spearP,weaponManagerScript.masterSpawnPoint);
                break;
                case "hammer":
                weaponManagerScript.SpawnPlayer(weaponManagerScript.hammerP,weaponManagerScript.masterSpawnPoint);
                break;
                case "axe":
                weaponManagerScript.SpawnPlayer(weaponManagerScript.axeP,weaponManagerScript.masterSpawnPoint);
                break;
                case "mace":
                weaponManagerScript.SpawnPlayer(weaponManagerScript.maceP,weaponManagerScript.masterSpawnPoint);
                break;
                default:
                Debug.Log("Ceva nu merge la respawn master");
                break;
            }
        }
        else
        {
            switch(WeaponManager.clientPlayer)
            {
                case "sword":
                weaponManagerScript.SpawnPlayer(weaponManagerScript.swordP,weaponManagerScript.clientSpawnPoint);
                break;
                case "spear":
                weaponManagerScript.SpawnPlayer(weaponManagerScript.spearP,weaponManagerScript.clientSpawnPoint);
                break;
                case "hammer":
                weaponManagerScript.SpawnPlayer(weaponManagerScript.hammerP,weaponManagerScript.clientSpawnPoint);
                break;
                case "axe":
                weaponManagerScript.SpawnPlayer(weaponManagerScript.axeP,weaponManagerScript.clientSpawnPoint);
                break;
                case "mace":
                weaponManagerScript.SpawnPlayer(weaponManagerScript.maceP,weaponManagerScript.clientSpawnPoint);
                break;
                default:
                Debug.Log("Ceva nu merge la respawn client");
                break;
            }
        }
        DestroyAllPlayers();
    }
    void DestroyAllPlayers()
    {
        PhotonNetwork.Destroy(PhotonView.Find(masterID));
        PhotonNetwork.Destroy(PhotonView.Find(clientID));
    }
}

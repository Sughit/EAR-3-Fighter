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
    [Space]
    public static GameObject masterGO;
    public static GameObject clientGO;
    
    void Awake()
    {
        instance=this;
    }

    void Start()
    {
        weaponManagerScript=weaponManager.GetComponent<WeaponManager>();
        GameObject _weaponManager = Instantiate(weaponManager, Vector3.zero, Quaternion.identity);
        Debug.Log("You joined "+ PhotonNetwork.CurrentRoom.Name);   
    }
    public void RespawnPlayer()
    {
        GameObject[] playersArray = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject player in playersArray)
        {
            if(player.GetComponent<PhotonView>().Owner.IsMasterClient)
            {
                player.GetComponent<Viata>().health=100f;
                player.transform.position = new Vector3(WeaponManager.masterSpawnPoint.position.x,
                                                        WeaponManager.masterSpawnPoint.position.y,
                                                        WeaponManager.masterSpawnPoint.position.z);
            }
            else
            {
                player.GetComponent<Viata>().health=100f;
                player.transform.position = new Vector3(WeaponManager.clientSpawnPoint.position.x,
                                                        WeaponManager.clientSpawnPoint.position.y,
                                                        WeaponManager.clientSpawnPoint.position.z);
            }
        }

        // DestroyAllPlayers();
        // GameObject[] playersArray = GameObject.FindGameObjectsWithTag("Player");
        // foreach(GameObject player in playersArray)
        // {
        //     if(player.GetComponent<PhotonView>().Owner.IsMasterClient)
        //     {
        //         weaponManagerScript.SpawnPlayer(player.GetComponent<PlayerSetup>().playerTypeGO, weaponManagerScript.masterSpawnPoint);
        //     }
        //     else
        //     {
        //         weaponManagerScript.SpawnPlayer(player.GetComponent<PlayerSetup>().playerTypeGO, weaponManagerScript.clientSpawnPoint);
        //     }
        // }
    }
    // void DestroyAllPlayers()
    // {
    //     PhotonNetwork.Destroy(PhotonView.Find(masterID));
    //     PhotonNetwork.Destroy(PhotonView.Find(clientID));
    // }
}

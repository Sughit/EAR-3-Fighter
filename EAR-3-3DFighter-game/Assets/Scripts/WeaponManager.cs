using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Hashtable=ExitGames.Client.Photon.Hashtable;

public class WeaponManager : MonoBehaviourPunCallbacks
{
    public GameObject swordP;
    public GameObject spearP;
    public GameObject hammerP;
    public GameObject axeP;
    public GameObject maceP;
    [Space]
    public static Transform masterSpawnPoint;
    public static Transform clientSpawnPoint;
    [Space]
    public static string masterPlayer;
    public static string clientPlayer;
    [Space]
    public static GameObject masterPlayerGO;
    public static GameObject clientPlayerGO;
    [Space]
    public static bool masterJoined;
    public static bool clientJoined;
    [Space]
    [Header("Managers")]
    public RoomManager roomManager1v1;

    void Awake()
    {
        roomManager1v1=GameObject.Find("RoomManager1v1").GetComponent<RoomManager>();
        masterSpawnPoint=GameObject.Find("masterSpawnPoint").GetComponent<Transform>();
        clientSpawnPoint=GameObject.Find("clientSpawnPoint").GetComponent<Transform>();
    }

    public void SpawnSwordPlayer()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            masterPlayer="sword";
            SpawnPlayer(swordP, masterSpawnPoint);
            //SpawnMasterPlayer(swordP, masterSpawnPoint);
        }
        else
        {
            clientPlayer="sword";
            SpawnPlayer(swordP, clientSpawnPoint);
            //SpawnClientPlayer(swordP, clientSpawnPoint);
        }
        Destroy(this.gameObject);
    }

    public void SpawnSpearPlayer()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            masterPlayer="spear";
            SpawnPlayer(spearP, masterSpawnPoint);
            //SpawnMasterPlayer(spearP, masterSpawnPoint);
        }
        else
        {
            clientPlayer="spear";
            SpawnPlayer(spearP, clientSpawnPoint);
            //SpawnClientPlayer(spearP, clientSpawnPoint);
        }
        Destroy(this.gameObject);
    }

    public void SpawnHammerPlayer()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            masterPlayer="hammer";
            SpawnPlayer(hammerP, masterSpawnPoint);
            //SpawnMasterPlayer(hammerP, masterSpawnPoint);
        }
        else
        {
            clientPlayer="hammer";
            SpawnPlayer(hammerP, clientSpawnPoint);
            //SpawnClientPlayer(hammerP, clientSpawnPoint);
        }
        Destroy(this.gameObject);
    }

    public void SpawnAxePlayer()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            masterPlayer="axe";
            SpawnPlayer(axeP, masterSpawnPoint);
            //SpawnMasterPlayer(axeP, masterSpawnPoint);
        }
        else
        {
            clientPlayer="axe";
            SpawnPlayer(axeP, clientSpawnPoint);
            //SpawnClientPlayer(axeP, clientSpawnPoint);
        }
        Destroy(this.gameObject);
    }

    public void SpawnMacePlayer()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            masterPlayer="mace";
            SpawnPlayer(maceP, masterSpawnPoint);
            //SpawnMasterPlayer(maceP, masterSpawnPoint);
        }
        else
        {
            clientPlayer="mace";
            SpawnPlayer(maceP, clientSpawnPoint);
            //SpawnClientPlayer(maceP, clientSpawnPoint);
        }
        Destroy(this.gameObject);
    }

    public void SpawnPlayer(GameObject go, Transform trans)
    {
        GameObject _player = PhotonNetwork.Instantiate(go.name, trans.position, Quaternion.identity);
        if(PhotonNetwork.IsMasterClient)
        {
            masterPlayerGO=_player;
            masterJoined=true;
            Debug.Log("Master id "+RoomManager.masterID);
        }
        else
        {
            clientPlayerGO=_player;
            clientJoined=true;
            Debug.Log("Client id "+RoomManager.clientID);
        }
        _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        _player.GetComponent<PlayerSetup>().GetPlayerType(go);
    }

    // public void SpawnMasterPlayer(GameObject go, Transform trans)
    // {
    //     //spawn player
    //     roomManager1v1.masterGO = PhotonNetwork.Instantiate(go.name, trans.position, Quaternion.identity) as GameObject;
    //     roomManager1v1.masterGO.GetComponent<PlayerSetup>().IsLocalPlayer();
        
    //     //verification
    //     masterJoined=true;
    //     Debug.Log("Master id "+RoomManager.masterID);
    // }
    
    // public void SpawnClientPlayer(GameObject go, Transform trans)
    // {
    //     //spawn player
    //     roomManager1v1.clientGO = PhotonNetwork.Instantiate(go.name, trans.position, Quaternion.identity) as GameObject;
    //     roomManager1v1.clientGO.GetComponent<PlayerSetup>().IsLocalPlayer();
        
    //     //verification
    //     clientJoined=true;
    //     Debug.Log("Client id "+RoomManager.clientID);
    // }
}

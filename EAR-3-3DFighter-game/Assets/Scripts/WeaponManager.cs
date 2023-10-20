using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviourPunCallbacks
{
    public GameObject swordP;
    public GameObject spearP;
    public GameObject hammerP;
    public GameObject axeP;
    public GameObject maceP;
    [Space]
    public Transform masterSpawnPoint;
    public Transform clientSpawnPoint;
    [Space]
    public static string masterPlayer;
    public static string clientPlayer;

    void Awake()
    {
        masterSpawnPoint=GameObject.Find("masterSpawnPoint").GetComponent<Transform>();
        clientSpawnPoint=GameObject.Find("clientSpawnPoint").GetComponent<Transform>();
    }

    public void SpawnSwordPlayer()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            masterPlayer="sword";
            SpawnPlayer(swordP, masterSpawnPoint);
        }
        else
        {
            clientPlayer="sword";
            SpawnPlayer(swordP, clientSpawnPoint);
        }
        Debug.Log("merge");
        Destroy(this.gameObject);
    }

    public void SpawnSpearPlayer()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            masterPlayer="spear";
            SpawnPlayer(spearP, masterSpawnPoint);
        }
        else
        {
            clientPlayer="spear";
            SpawnPlayer(spearP, clientSpawnPoint);
        }
        Destroy(this.gameObject);
    }

    public void SpawnHammerPlayer()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            masterPlayer="hammer";
            SpawnPlayer(hammerP, masterSpawnPoint);
        }
        else
        {
            clientPlayer="hammer";
            SpawnPlayer(hammerP, clientSpawnPoint);
        }
        Destroy(this.gameObject);
    }

    public void SpawnAxePlayer()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            masterPlayer="axe";
            SpawnPlayer(axeP, masterSpawnPoint);
        }
        else
        {
            clientPlayer="axe";
            SpawnPlayer(axeP, clientSpawnPoint);
        }
        Destroy(this.gameObject);
    }

    public void SpawnMacePlayer()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            masterPlayer="mace";
            SpawnPlayer(maceP, masterSpawnPoint);
        }
        else
        {
            clientPlayer="mace";
            SpawnPlayer(maceP, clientSpawnPoint);
        }
        Destroy(this.gameObject);
    }

    public void SpawnPlayer(GameObject go, Transform trans)
    {
        GameObject _player = PhotonNetwork.Instantiate(go.name, trans.position, Quaternion.identity);
        _player.GetComponent<PlayerSetup>().IsLocalPlayer();
    }
    
}

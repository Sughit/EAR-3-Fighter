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

    void Awake()
    {
        masterSpawnPoint=GameObject.Find("masterSpawnPoint").GetComponent<Transform>();
        clientSpawnPoint=GameObject.Find("clientSpawnPoint").GetComponent<Transform>();
    }

    public void SpawnSwordPlayer()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            GameObject _player = PhotonNetwork.Instantiate(swordP.name, masterSpawnPoint.position, Quaternion.identity);
            _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        }
        else
        {
            GameObject _player = PhotonNetwork.Instantiate(swordP.name, clientSpawnPoint.position, Quaternion.identity);
            _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        }
        Debug.Log("merge");
        Destroy(this.gameObject);
    }

    public void SpawnSpearPlayer()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            GameObject _player = PhotonNetwork.Instantiate(spearP.name, masterSpawnPoint.position, Quaternion.identity);
            _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        }
        else
        {
            GameObject _player = PhotonNetwork.Instantiate(spearP.name, clientSpawnPoint.position, Quaternion.identity);
            _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        }
        Destroy(this.gameObject);
    }

    public void SpawnHammerPlayer()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            GameObject _player = PhotonNetwork.Instantiate(hammerP.name, masterSpawnPoint.position, Quaternion.identity);
            _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        }
        else
        {
            GameObject _player = PhotonNetwork.Instantiate(hammerP.name, clientSpawnPoint.position, Quaternion.identity);
            _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        }
        Destroy(this.gameObject);
    }

    public void SpawnAxePlayer()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            GameObject _player = PhotonNetwork.Instantiate(axeP.name, masterSpawnPoint.position, Quaternion.identity);
            _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        }
        else
        {
            GameObject _player = PhotonNetwork.Instantiate(axeP.name, clientSpawnPoint.position, Quaternion.identity);
            _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        }
        Destroy(this.gameObject);
    }

    public void SpawnMacePlayer()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            GameObject _player = PhotonNetwork.Instantiate(maceP.name, masterSpawnPoint.position, Quaternion.identity);
            _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        }
        else
        {
            GameObject _player = PhotonNetwork.Instantiate(maceP.name, clientSpawnPoint.position, Quaternion.identity);
            _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        }
        Destroy(this.gameObject);
    }
}

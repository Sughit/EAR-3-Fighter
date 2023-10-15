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
    [Space]
    public Transform spawnPoint;

    void Awake()
    {
        spawnPoint=GameObject.Find("SpawnPoint").GetComponent<Transform>();
    }

    public void SpawnSwordPlayer()
    {
        GameObject _player = PhotonNetwork.Instantiate(swordP.name, spawnPoint.position, Quaternion.identity);
        _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        Destroy(this.gameObject);
    }

    public void SpawnSpearPlayer()
    {
        GameObject _player = PhotonNetwork.Instantiate(spearP.name, spawnPoint.position, Quaternion.identity);
        _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        Destroy(this.gameObject);
    }

    public void SpawnHammerPlayer()
    {
        GameObject _player = PhotonNetwork.Instantiate(hammerP.name, spawnPoint.position, Quaternion.identity);
        _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        Destroy(this.gameObject);
    }
}

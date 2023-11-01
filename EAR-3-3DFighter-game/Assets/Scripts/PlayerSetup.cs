using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerSetup : MonoBehaviour
{
    [Header("enabled")]
    public Movement2 movement;
    public GameObject camera;
    public GameObject triggerAtac;
    public GameObject VCam;
    public GameObject HUD;
    [Header("disabled")]
    public GameObject healthBar;
    public GameObject TextInceput;
    [Header("properties")]
    public GameObject playerTypeGO;

    public void IsLocalPlayer()
    {
        movement.enabled = true;
        triggerAtac.SetActive(true);
        camera.SetActive(true);
        VCam.SetActive(true);
        HUD.SetActive(true);
        healthBar.SetActive(false);
        TextInceput.SetActive(true);
        if(PhotonNetwork.IsMasterClient)
        {
            RoomManager.masterID=this.GetComponent<PhotonView>().ViewID;
        }
        else
        {
            RoomManager.clientID=this.GetComponent<PhotonView>().ViewID;
        }
    }

    public void GetPlayerType(GameObject _playerTypeGO)
    {
        playerTypeGO=_playerTypeGO;
        if(PhotonNetwork.IsMasterClient)
        {
            RoomManager.masterGO=_playerTypeGO;
        }
        else
        {
            RoomManager.clientGO=_playerTypeGO;
        }
    }
}

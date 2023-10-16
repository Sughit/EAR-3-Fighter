using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using UnityEngine.UI;

public class ConnectToPhoton : MonoBehaviourPunCallbacks
{
    public Text text;
    void Start()
    {
        Debug.Log("Connecting...");
        PhotonNetwork.ConnectUsingSettings();
        text.text="prima faza a trecut";
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to server");
        PhotonNetwork.JoinLobby();
        text.text="a doua faza a trecut";
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Soon you will be able to join/create room");
        text.text="a treia faza a trecut";
        SceneManager.LoadScene("Meniu");
    }
}

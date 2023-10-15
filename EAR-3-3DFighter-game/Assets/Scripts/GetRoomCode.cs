using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class GetRoomCode : MonoBehaviourPunCallbacks
{
    public Text roomCode;
    public Text joinRoomCode;

    public static string gameMode;

    public void CreateRoom()
    {
        if(roomCode.text!=null)
        {
            if(gameMode!=null)
            {
                PhotonNetwork.CreateRoom(roomCode.text);
            }
        }
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoomCode.text);
    }

    public override void OnJoinedRoom()
    {
        if(roomCode.text!="")
        {
            switch (gameMode)
            {
                case "1v1":
                PhotonNetwork.LoadLevel("1v1");
                break;
                case "1v1DF":
                PhotonNetwork.LoadLevel("1v1DF");
                break;
                case "wave":
                PhotonNetwork.LoadLevel("wave");
                break;
                default:
                Debug.Log("Select a game mode");
                break;
            }
        }
    }

    public void SetGameMode(string _gameMode)
    {
        gameMode = _gameMode;
    }
}

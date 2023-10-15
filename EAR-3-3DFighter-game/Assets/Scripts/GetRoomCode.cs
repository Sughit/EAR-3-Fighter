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

    public void ManageRoomCode()
    {
        if(roomCode.text!="")
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.CreateRoom(roomCode.name);
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
        else 
        {
            Debug.Log("Enter a room code");
        }
    }

    public void JoinRoom()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.JoinRoom(joinRoomCode.name);
    }

    public void SetGameMode(string _gameMode)
    {
        gameMode = _gameMode;
    }
}

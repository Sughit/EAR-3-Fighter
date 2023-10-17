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
//am fost de pe telefon aici
    public static string gameMode;
    public Text text;
    bool canLoadScene;

    // void Update()
    // {
    //     if(PhotonNetwork.InRoom)
    //     {
    //         CheckNumOfPlayers();
    //     }
    // }

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
        PhotonNetwork.AutomaticallySyncScene=true;
        PhotonNetwork.JoinRoom(joinRoomCode.text);
        Debug.Log("merge");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("suntem intr-o camera");
        Debug.Log("in camera "+PhotonNetwork.CurrentRoom.Name);
        Debug.Log("camera are "+PhotonNetwork.CurrentRoom.PlayerCount);
        text.text="Suntem intr-o camera| nume: "+PhotonNetwork.CurrentRoom.Name.ToString()+"| nr playeri:"+PhotonNetwork.CurrentRoom.PlayerCount.ToString();
    }

    public override void OnJoinRoomFailed(short returnCode, string message) 
    {
        Debug.Log("Failed to join room ");
    }

    public void SetGameMode(string _gameMode)
    {
        gameMode = _gameMode;
    }

    public void StartGame()
    {
        // if(PhotonNetwork.CurrentRoom.PlayerCount == 2)
        // {
        //     canLoadScene=true;
        //     if(canLoadScene)
        //     {
        //         //if(PhotonNetwork.IsMasterClient)
        //         //{
                    
        //             switch (gameMode)
        //         {
        //             case "1v1":
        //             canLoadScene=false;
        //             PhotonNetwork.LoadLevel("1v1");
        //             break;
        //             case "1v1DF":
        //             canLoadScene=false;
        //             PhotonNetwork.LoadLevel("1v1DF");
        //             break;
        //             case "wave":
        //             canLoadScene=false;
        //             PhotonNetwork.LoadLevel("wave");
        //             break;
        //             default:
        //             canLoadScene=false;
        //             Debug.Log("Select a game mode");
        //             break;
        //         }
        //         //}
        //     }
        // }
        if(PhotonNetwork.IsMasterClient)
        {
            switch (gameMode)
                {
                    case "1v1":
                    canLoadScene=false;
                    PhotonNetwork.LoadLevel("1v1");
                    break;
                    case "1v1DF":
                    canLoadScene=false;
                    PhotonNetwork.LoadLevel("1v1DF");
                    break;
                    case "wave":
                    canLoadScene=false;
                    PhotonNetwork.LoadLevel("wave");
                    break;
                    default:
                    canLoadScene=false;
                    Debug.Log("Select a game mode");
                    break;
                }
        }
    }
}

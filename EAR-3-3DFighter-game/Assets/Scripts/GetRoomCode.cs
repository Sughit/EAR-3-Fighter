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
    [PunRPC]
    public static string gameMode;
    public static string modDeJoc;
    public Text text;
    public GameObject createRoomGO;
    public GameObject inRoomGO;
    public GameObject joinRoomGO;
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

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("suntem intr-o camera");
        Debug.Log("in camera "+PhotonNetwork.CurrentRoom.Name);
        Debug.Log("camera are "+PhotonNetwork.CurrentRoom.PlayerCount);
        text.text="Suntem intr-o camera| nume: "+PhotonNetwork.CurrentRoom.Name.ToString()+"| nr playeri:"+PhotonNetwork.CurrentRoom.PlayerCount.ToString();
        createRoomGO.SetActive(false);
        inRoomGO.SetActive(true);
        joinRoomGO.SetActive(false);
    }

    public override void OnJoinRoomFailed(short returnCode, string message) 
    {
        Debug.Log("Failed to join room ");
    }

    public void SetGameMode(string _gameMode)
    {
        gameMode = _gameMode;
        modDeJoc = gameMode;
    }

    public void StartGame()
    {
        if(PhotonNetwork.IsMasterClient)
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

}

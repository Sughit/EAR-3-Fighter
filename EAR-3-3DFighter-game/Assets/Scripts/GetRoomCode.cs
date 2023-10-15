using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetRoomCode : MonoBehaviour
{
    public Text roomCode;
    public void ManageRoomCode()
    {
        if(roomCode.text!="")
        {
            RoomManager.roomCode = roomCode.text;
            SceneManager.LoadScene(1);
        }
        else 
        {
            Debug.Log("Enter a room code");
        }
    }
}

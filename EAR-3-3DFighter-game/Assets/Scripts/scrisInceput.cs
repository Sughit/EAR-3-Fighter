using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class scrisInceput : MonoBehaviour
{
    public Text text;
    Animator anim;
    PhotonView p;
    public static string currentScene;
    void Awake()
    {
        currentScene=SceneManager.GetActiveScene().name;
        PhotonView PV = GetComponent<PhotonView>();
        anim = GetComponent<Animator>();
        SetupText();
        StartCoroutine(DupaCevaTimp());
    }
    [PunRPC]
    void SetupText()
    {
        switch (GameObject.Find(GetRoomManagerName()).GetComponent<RoomManager>().nume)
        {
            case "1v1":
            text.text= "Your goal is to kill the other Enemy";
            break;
            case "1v1DF":
            text.text= "Your goal is to kill the other Enemy";
            break;
            case "wave":
            text.text= "Your goal is to survive as much as you can";
            break;
            default:
            text.text= "nu ar trebui sa vezi asta";
            break;
        }
    }
    IEnumerator DupaCevaTimp()
    {
        yield return new WaitForSeconds(3f);
        anim.SetTrigger("AnimatieText");

    }
    string GetRoomManagerName()
    {
        if(currentScene=="1v1") return "RoomManager1v1";
        else if(currentScene=="1v1DF") return "RoomManager1v1DF";
        else if(currentScene=="wave") return "RoomManagerWave";
        else return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class scrisInceput : MonoBehaviour
{
    public Text text;
    Animator anim;
    PhotonView p;
    void Awake()
    {
        PhotonView PV = GetComponent<PhotonView>();
        anim = GetComponent<Animator>();
        SetupText();
        StartCoroutine(DupaCevaTimp());
    }
    [PunRPC]
    void SetupText()
    {
        switch (GameObject.Find("RoomManager").GetComponent<RoomManager>().nume)
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

}

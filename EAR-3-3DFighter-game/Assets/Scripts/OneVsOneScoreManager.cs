using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class OneVsOneScoreManager : MonoBehaviour
{
    public static int masterScore;
    public static int clientScore;
    [Space]
    public Text masterScoreText;
    public Text clientScoreText;

    void Update()
    {
        // Debug.Log("Master score: "+masterScore);
        // Debug.Log("Client score: "+clientScore);
        if(WeaponManager.masterJoined)
        {
            this.GetComponent<PhotonView>().RPC("UpdateScore" , RpcTarget.All, null);
        }
        // UpdateScore();
    }

    [PunRPC]
    void UpdateScore()
    {
        masterScoreText.text="M:"+masterScore.ToString();
        clientScoreText.text="C:"+clientScore.ToString();
    }

    public void IncreaseClientScore()
    {   
        clientScore++;
        this.GetComponent<PhotonView>().RPC("UpdateScore" , RpcTarget.All, null);
    }

    public void IncreaseMasterScore()
    {
        masterScore++;
        this.GetComponent<PhotonView>().RPC("UpdateScore" , RpcTarget.All, null);
    }

    public void LockCursor()
    {
        Cursor.lockState=CursorLockMode.Locked;
    }
}

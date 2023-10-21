using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Viata : MonoBehaviour
{
    public float health=100f;
    public Slider sliderViata;
    public Slider sliderHUD;
    public Text text1;
    public Text text2;
    float x;

    public float fullHealth=100f;
    void Awake()
    {
        sliderViata.value= health / fullHealth;
        sliderHUD.value= health / fullHealth;
        text1.text= x.ToString();
        text2.text= x.ToString();
    }
    void Update()
    {
                x =health/fullHealth*100;
        sliderViata.value= health / fullHealth;
        sliderHUD.value= health / fullHealth;
        text1.text= x.ToString();
        text2.text= x.ToString();
        if(health<=0)
        {
            Moarte();
        }
    }
    [PunRPC]
    public void TakeDamage(float damage)
    {
        health-=damage;
    }
    public void Moarte()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            OneVsOneScoreManager.clientScore++;
        }
        else 
        {
            OneVsOneScoreManager.masterScore++;
        }
        ShowUpgradeTree();
        RoomManager.instance.RespawnPlayer();
    }

    void ShowUpgradeTree()
    {
        Debug.Log("poti upgrada");
    }
}

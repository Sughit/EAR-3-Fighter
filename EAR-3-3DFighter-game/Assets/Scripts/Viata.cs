using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Viata : MonoBehaviour
{
    public float health=100f;
    public float fullHealth=100f;
    [Space]
    public Slider sliderViata;
    public Slider sliderHUD;
    [Space]
    public Text text1;
    public Text text2;
    float x;
    [Space]
    public GameObject masterSkillTree;
    public GameObject clientSkillTree;
    [Space]
    bool canIncreaseScore;

    void Awake()
    {
        canIncreaseScore=true;
        if(scrisInceput.currentScene=="1v1")
        {
            Debug.Log("Suntem in 1v1");
        }
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
        if(canIncreaseScore)
        {
            if(PhotonNetwork.IsMasterClient)
            {
                if(health==0)
                {
                    OneVsOneScoreManager.clientScore++;
                    if(scrisInceput.currentScene=="1v1")
                    {
                        Cursor.lockState=CursorLockMode.None;
                        ShowUpgradeTree();
                    }
                }
                else
                {
                    OneVsOneScoreManager.masterScore++;
                    if(scrisInceput.currentScene=="1v1")
                    {
                        Cursor.lockState=CursorLockMode.None;
                        ShowUpgradeTree();
                    }
                }
            }
            canIncreaseScore=false;
        }
        
        // RoomManager.instance.RespawnPlayer();
    }

    void ShowUpgradeTree()
    {
        Debug.Log("poti upgrada");
        if(PhotonNetwork.IsMasterClient)
        {
            masterSkillTree.SetActive(true);
        }
        else
        {
            clientSkillTree.SetActive(true);
        }
    }
}

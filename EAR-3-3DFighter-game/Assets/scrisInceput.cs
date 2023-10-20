using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrisInceput : MonoBehaviour
{
    public Text text;
    Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
        SetupText();
        StartCoroutine(DupaCevaTimp());
    }

    void SetupText()
    {
        switch (GetRoomCode.gameMode)
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class atacTest : MonoBehaviour
{
    Viata viata;
    public float damage = 5f;
    bool ableToAtac= true;
    public float cooldown = 0.5f;
    Collider col;
    bool click;
    bool ok=false;
    void Awake()
    {
        ok=false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                StartCoroutine(Atac(damage));
            }
        Debug.Log(ok);

        if(ok)
            StartCoroutine(OK());
    }

    IEnumerator OK()
    {
            yield return new WaitForSeconds(0.01f);
            ok=false;
    }
    IEnumerator Atac(float damageAtac)
    {

        if(ableToAtac)
        {
            ok=true;

            ableToAtac=false;

            yield return new WaitForSeconds(cooldown);

            ableToAtac = true;
        }          
    }

    void OnTriggerStay(Collider col)
    { 
        if(col.gameObject.tag == "Player" && ok==true)
            {
                    col.GetComponent<PhotonView>().RPC("TakeDamage" , RpcTarget.All, damage);
                    ok=false;
                    Debug.Log("merge");
            }
        else ok=false;                              
    }
}

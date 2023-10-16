using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atacTest : MonoBehaviour
{
    Viata viata;
    public float damage = 5f;
    public GameObject text;
    bool ableToAtac= true;
    public float cooldown = 1f;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                StartCoroutine(Atac(damage));
            }
            Debug.Log(ableToAtac);
    }

    IEnumerator Atac(float damageAtac)
    {
        if(ableToAtac)
        {
            ableToAtac=false;

            if(viata == null)
            {
                yield return new WaitForSeconds(cooldown);
                ableToAtac=true;
            }
            else
            {
                viata.TakeDamage( damageAtac);
                StartCoroutine(ArataTextTest());

                yield return new WaitForSeconds(cooldown);
                ableToAtac = true;
            }
        }          
    }

    void OnTriggerStay(Collider col)
    { 
        if(col.gameObject.tag == "Player")
            viata=col.GetComponent<Viata>();
        else 
            viata = null; 
    }
    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Player")
            viata = null;
    }
    IEnumerator ArataTextTest()
    {
        text.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        text.SetActive(false);
    }
}

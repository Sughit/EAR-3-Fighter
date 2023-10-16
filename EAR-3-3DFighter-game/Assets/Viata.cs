using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Viata : MonoBehaviour
{
    public float health=100f;
    public Slider sliderViata;
    public float fullHealth=100f;
    void Update()
    {
        sliderViata.value= health / fullHealth;

        if(health<=0)
        {
            Moarte();
        }
    }
    public void TakeDamage(float damage)
    {
        health-=damage;
    }
    public void Moarte()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class viata2Doi : MonoBehaviour
{
    Viata viata;
    public Slider sliderHUD;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sliderHUD.value=viata.health/viata.fullHealth;
    }
}

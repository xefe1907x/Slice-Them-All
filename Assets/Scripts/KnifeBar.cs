using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBar : MonoBehaviour
{
    public GameObject knifeBar1;
    public GameObject knifeBar2;
    public GameObject knifeBar3;
    public GameObject knifeBar4;

    bool isBarInstantiated = true;

    void Update()
    {
        KnifeShownInBar();
    }

    void KnifeShownInBar()
    {
        if (isBarInstantiated)
        {
            if (PlayerPrefs.GetInt("knifeNumber") == 0)
            {
                knifeBar1.SetActive(true);
                isBarInstantiated = false;
            }
            
            else if (PlayerPrefs.GetInt("knifeNumber") == 1)
            {
                knifeBar1.SetActive(true);
                isBarInstantiated = false;
            }
            
            else if (PlayerPrefs.GetInt("knifeNumber") == 2)
            {
                knifeBar1.SetActive(true);
                isBarInstantiated = false;
            }
            
            else if (PlayerPrefs.GetInt("knifeNumber") == 3)
            {
                knifeBar1.SetActive(true);
                isBarInstantiated = false;
            }
        }
    }
}

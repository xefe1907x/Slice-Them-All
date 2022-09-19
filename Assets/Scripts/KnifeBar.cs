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

    public static bool isBarInstantiated = true;
    public static bool isBarReset;

    void Update()
    {
        KnifeShownInBar();
        ResetBars();
    }

    void ResetBars()
    {
        if (isBarReset)
        {
            if (knifeBar1.activeInHierarchy)
            {
                knifeBar1.SetActive(false);
            }
            
            if (knifeBar2.activeInHierarchy)
            {
                knifeBar2.SetActive(false);
            }
            
            if (knifeBar3.activeInHierarchy)
            {
                knifeBar3.SetActive(false);
            }
            
            if (knifeBar4.activeInHierarchy)
            {
                knifeBar4.SetActive(false);
            }
            
            isBarReset = false;
            isBarInstantiated = true;
        }
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
                knifeBar2.SetActive(true);
                isBarInstantiated = false;
            }
            
            else if (PlayerPrefs.GetInt("knifeNumber") == 2)
            {
                knifeBar3.SetActive(true);
                isBarInstantiated = false;
            }
            
            else if (PlayerPrefs.GetInt("knifeNumber") == 3)
            {
                knifeBar4.SetActive(true);
                isBarInstantiated = false;
            }
        }
    }
}

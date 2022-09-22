using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailBar : MonoBehaviour
{
    public GameObject trailBar1;
    public GameObject trailBar2;
    public GameObject trailBar3;
    public GameObject trailBar4;

    public static bool isTrailInstantiated = true;
    public static bool isTrailReset;

    void Start()
    {
        isTrailInstantiated = true;
        isTrailReset = false;
    }

    void Update()
    {
        TrailShownInBar();
        ResetTrailBars();
    }

    void ResetTrailBars()
    {
        if (isTrailReset)
        {
            if (trailBar1.activeInHierarchy)
            {
                trailBar1.SetActive(false);
            }
            
            if (trailBar2.activeInHierarchy)
            {
                trailBar2.SetActive(false);
            }
            
            if (trailBar3.activeInHierarchy)
            {
                trailBar3.SetActive(false);
            }
            
            if (trailBar4.activeInHierarchy)
            {
                trailBar4.SetActive(false);
            }
            
            isTrailReset = false;
            isTrailInstantiated = true;
        }
    }

    void TrailShownInBar()
    {
        if (isTrailInstantiated)
        {
            if (PlayerPrefs.GetInt("trailNumber") == 0)
            {
                trailBar1.SetActive(true);
                isTrailInstantiated = false;
            }
            
            else if (PlayerPrefs.GetInt("trailNumber") == 1)
            {
                trailBar2.SetActive(true);
                isTrailInstantiated = false;
            }
            
            else if (PlayerPrefs.GetInt("trailNumber") == 2)
            {
                trailBar3.SetActive(true);
                isTrailInstantiated = false;
            }
            
            else if (PlayerPrefs.GetInt("trailNumber") == 3)
            {
                trailBar4.SetActive(true);
                isTrailInstantiated = false;
            }
        }
    }
}

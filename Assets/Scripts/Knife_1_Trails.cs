using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife_1_Trails : MonoBehaviour
{
    public GameObject trail1;
    public GameObject trail2;
    public GameObject trail3;
    public GameObject trail4;

    int trailNumber;

    public static bool isTrailActivated;
    void Start()
    {
        trailNumber = PlayerPrefs.GetInt("trailNumber");
    }

    void Update()
    {
        TrailController();
    }

    void TrailController()
    {
        if (!isTrailActivated)
        {
            switch (trailNumber)
            {
                case 0:
                    trail1.SetActive(true);
                    isTrailActivated = true;
                    break;
                case 1:
                    trail2.SetActive(true);
                    isTrailActivated = true;
                    break;
                case 2:
                    trail3.SetActive(true);
                    isTrailActivated = true;
                    break;
                case 3:
                    trail4.SetActive(true);
                    isTrailActivated = true;
                    break;
            }
        }
    }
}

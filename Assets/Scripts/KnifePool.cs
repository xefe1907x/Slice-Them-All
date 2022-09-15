using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class KnifePool : MonoBehaviour
{
    int knifeNumber;

    bool isknifeInstantiated;

    public GameObject knifePrefab1;
    public GameObject knifePrefab2;
    public GameObject knifePrefab3;
    public GameObject knifePrefab4;

    void Start()
    {
        knifeNumber = 4; // TODO: playprefste kaydet hangi bıçak kullanılıyo ona göre instantiate et
    }

    void Update()
    {
        KnifeSelector();
    }
    
    void KnifeSelector()
    {
        if (!isknifeInstantiated)
        {
            switch (knifeNumber)
            {
                case 1:
                    Instantiate(knifePrefab1, new Vector3(6.32f, 4.45f, 0f), Quaternion.Euler(-242.3f,86.62f,-2.05f));
                    isknifeInstantiated = true;
                    break;
                case 2:
                    Instantiate(knifePrefab2, new Vector3(6.73f, 5.65f, 0f), Quaternion.Euler(-416.36f,86.47f,-0.7f));
                    isknifeInstantiated = true;
                    break;
                case 3:
                    Instantiate(knifePrefab3, new Vector3(6.68f, 5.5f, 0f), Quaternion.Euler(-59.51f,86.15f,-4.17f));
                    isknifeInstantiated = true;
                    break;
                case 4:
                    Instantiate(knifePrefab4, new Vector3(6.46f, 5.12f, 0f), Quaternion.Euler(60.3f,-90f,0f));
                    isknifeInstantiated = true;
                    break;
            }
        }
    }
}
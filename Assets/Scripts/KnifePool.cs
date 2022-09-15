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
        knifeNumber = 1; // TODO: playprefste kaydet hangi bıçak kullanılıyo ona göre instantiate et
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
                    Instantiate(knifePrefab1, new Vector3(6.33f, 4.06f, 0f), Quaternion.Euler(122.83f,87.1f,-1.49f));
                    isknifeInstantiated = true;
                    break;
            }
        }
    }
}

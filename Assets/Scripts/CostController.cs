using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CostController : MonoBehaviour
{
    public TextMeshProUGUI cost2Text;
    public TextMeshProUGUI cost3Text;
    public TextMeshProUGUI cost4Text;
    
    int cost2;
    int cost3;
    int cost4;

    void Start()
    {
        cost2 = 5000;
        cost3 = 60000;
        cost4 = 185000;
    }

    void Update()
    {
        ShowCost();
    }

    void ShowCost()
    {
        cost2Text.text = "$ " + cost2;
        cost3Text.text = "$ " + cost3;
        cost4Text.text = "$ " + cost4;
    }
}

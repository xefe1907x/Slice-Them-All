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
    public TextMeshProUGUI cost6Text;
    public TextMeshProUGUI cost7Text;
    public TextMeshProUGUI cost8Text;
    
    int cost2; //First Knife
    int cost3; //Second Knife
    int cost4; //Third Knife
    int cost6; //First Effect
    int cost7; //Second Effect
    int cost8; //Third Effect

    void Start()
    {
        cost2 = 5000;
        cost3 = 60000;
        cost4 = 185000;
        cost6 = 15000;
        cost7 = 180000;
        cost8 = 555000;
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
        cost6Text.text = "$ " + cost6;
        cost7Text.text = "$ " + cost7;
        cost8Text.text = "$ " + cost8;
        
    }
}

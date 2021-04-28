﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] int money = 25;

    [SerializeField] TextMeshProUGUI moneyText;
    
    // Start is called before the first frame update
    void Start()
    {
        Item.ItemPickedUp += UpdateMoney;

        moneyText.text = "Cash: " + money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateMoney(int cost, string itemName)
    {
        Debug.Log("Money: " + money.ToString() + " Cost: " + cost.ToString());
        money -= cost;

        moneyText.text = "Cash: "  + money.ToString();
    }
}

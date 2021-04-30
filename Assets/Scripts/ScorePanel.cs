using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] int money = 25;

    [SerializeField] TextMeshProUGUI moneyText;

    [SerializeField] GameObject deathPanel;
    [SerializeField] TextMeshProUGUI deathTypeText;
    [SerializeField] TextMeshProUGUI deathDescriptionText;

    PlayerController player;
    
    // Start is called before the first frame update
    void Start()
    {
        Item.ItemPickedUp += UpdateMoney;

        FaceMask.FaceMaskPickedUp += SubFaceMaskCost;

        moneyText.text = "Cash: " + money.ToString();

        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateMoney(int cost, string itemName)
    {
       // Debug.Log("Money: " + money.ToString() + " Cost: " + cost.ToString());
        money -= cost;

        moneyText.text = "Cash: "  + money.ToString();

        CheckMoneyStatus();

        
    }

    private void SubFaceMaskCost(int cost)
    {
        money -= cost;

        moneyText.text = "Cash: " + money.ToString();

        CheckMoneyStatus();
    }

    private void OnDestroy()
    {
        Item.ItemPickedUp -= UpdateMoney;
        FaceMask.FaceMaskPickedUp -= SubFaceMaskCost;
    }

    void CheckMoneyStatus()
    {
        if(money < 10)
        {
            moneyText.color = Color.red;
        }

        if(money<0)
        {
            Debug.Log("Stopping Player Movement");
            player.SetCanMove(false);
            //Time.timeScale = 0;
            deathTypeText.text = "You spent too much!\n Cash = " + money.ToString();
            deathDescriptionText.text = "You went over your budget and have been removed from the store!  Better luck next time...";
            deathPanel.SetActive(true);
        }
    }
}

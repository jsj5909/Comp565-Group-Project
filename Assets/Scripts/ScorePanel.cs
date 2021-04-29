using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] int money = 25;

    [SerializeField] TextMeshProUGUI moneyText;

    [SerializeField] GameObject deathPanel;
    [SerializeField] TextMeshProUGUI deathTypeText;
    [SerializeField] TextMeshProUGUI deathDescriptionText;
    
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

        if(money < 10)
        {
            moneyText.color = Color.red;
        }

        if(money<0)
        {
            //Time.timeScale = 0;
            deathTypeText.text = "You spent too much!\n Cash = " + money.ToString();
            deathDescriptionText.text = "You went over your budget and have been removed from the store!  Better luck next time...";
            deathPanel.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        Item.ItemPickedUp -= UpdateMoney;
    }
}

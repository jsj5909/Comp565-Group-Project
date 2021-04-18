using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum ItemType { ToiletPaper, Water, PaperTowel, Food, Plates }


public class ItemPanel : MonoBehaviour
{
    [SerializeField] Image[] uiImages;

    [SerializeField] ItemData[] neededItems;
   
    List<string> playerItems;

    // Start is called before the first frame update
    void Start()
    {
        playerItems = new List<string>();
       
        InitializeUI();

        Item.ItemPickedUp += UpdateUI;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ItemPickedUp()
    {

    }

    void InitializeUI()
    {
        for(int i = 0; i < neededItems.Length; i++)
        {
            uiImages[i].sprite = neededItems[i].GetImage();
            uiImages[i].color = new Color(1, 1, 1, 1);
        }
    }

    void UpdateUI(int cost, string name)
    {
        for(int i=0; i < neededItems.Length;i++)
        {
            if(neededItems[i].GetName() == name)
            {
                uiImages[i].color = new Color(1, 1, 1, 0);
                if (!playerItems.Contains(name))
                {
                    playerItems.Add(name);
                }
                break;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




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

        Shoplifter.OnStealing += StealItem;

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

    public ItemData[] GetNeededItems()
    {
        return neededItems;
    }

    private void StealItem()
    {
        if (playerItems.Count < 1)
            return;
        
        int randomItem = Random.Range(0, playerItems.Count);

        string itemName = playerItems[randomItem];
        //Debug.LogError("Stolen: " + itemName);

        playerItems.RemoveAt(randomItem);

        for (int i = 0; i < neededItems.Length; i++)
        {
            if (neededItems[i].GetName() == itemName)
            {
                uiImages[i].color = new Color(1, 1, 1, 1);
                
                break;
            }
        }
       

    }

    private void OnDestroy()
    {
        Item.ItemPickedUp -= UpdateUI;
        Shoplifter.OnStealing -= StealItem;
    }
}

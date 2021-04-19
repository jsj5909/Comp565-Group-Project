using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneNamePanel : MonoBehaviour
{
   

    [SerializeField] Image[] uiImages;

    [SerializeField] GameObject itemPanel;

    [SerializeField] GameObject tutorialPanel;

    ItemData[] neededItems;

   

    // Start is called before the first frame update


    void Start()
    {

        tutorialPanel.SetActive(false);
        neededItems = itemPanel.GetComponent<ItemPanel>().GetNeededItems();
        InitializeUI();

      
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void InitializeUI()
    {
        for (int i = 0; i < neededItems.Length; i++)
        {
            uiImages[i].sprite = neededItems[i].GetImage();
            uiImages[i].color = new Color(1, 1, 1, 1);
        }
    }

   public void OkayPressed()
    {
        gameObject.SetActive(false);

        tutorialPanel.SetActive(true);
    }

}

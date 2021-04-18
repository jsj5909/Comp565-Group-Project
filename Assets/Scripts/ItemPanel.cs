using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum ItemType { ToiletPaper, Water, PaperTowel, Food, Plates }


public class ItemPanel : MonoBehaviour
{
    [SerializeField] Image toiletPaper;
    [SerializeField] Image water;
    [SerializeField] Image PaperTowel;
    [SerializeField] Image food;
    [SerializeField] Image plates;

    [SerializeField] ItemType[] neededItems;
    List<ItemType> playerItems;

    // Start is called before the first frame update
    void Start()
    {
       


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

    }
}

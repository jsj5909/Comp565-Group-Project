using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Item : MonoBehaviour
{
    // [SerializeField] protected int cost = 5;

   // [SerializeField] protected string itemName = string.Empty;

    [SerializeField] ItemData data;

    public static Action<int, string> ItemPickedUp;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (ItemPickedUp != null)
            {
                ItemPickedUp(data.GetCost(),data.GetName());
            }
           
            Destroy(gameObject);

        }
    }

   

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Item : MonoBehaviour
{
    [SerializeField] float rotateSpeed;

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
        if (other.transform.tag.Equals("Player"))
        {
            if (ItemPickedUp != null)
            {
               // Debug.LogError("ITEM PICKED UP");
                ItemPickedUp(data.GetCost(),data.GetName());
            }
           
            Destroy(gameObject);

        }
    }

   

}

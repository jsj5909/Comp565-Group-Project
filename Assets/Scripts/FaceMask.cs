using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FaceMask : MonoBehaviour
{

    [SerializeField] float rotateSpeed = 1;

    

    public static Action FaceMaskPickedUp;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            if(FaceMaskPickedUp != null)
            {
                FaceMaskPickedUp();
            }

            Destroy(gameObject);
        }
    }
}

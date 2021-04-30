using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shoplifter : MonoBehaviour
{

    [SerializeField] float timeBetweenThefts = 3;
    
    public static Action OnStealing;

    float nextTheftTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        nextTheftTime = Time.time + timeBetweenThefts;

    }

    // Update is called once per frame
    void Update()
    {

    }

    

    void OnTriggerStay(Collider other)
    {
        if (Time.time > nextTheftTime)
        {

            if (other.transform.tag.Equals("Player"))
            {
                if (OnStealing != null)
                {
                    OnStealing();
                }

                nextTheftTime = Time.time + timeBetweenThefts;
            }
        }
    }

    




}

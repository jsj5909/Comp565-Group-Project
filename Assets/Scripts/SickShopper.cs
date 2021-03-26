using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SickShopper : MonoBehaviour
{

    [SerializeField] float reduceHealthModifier = 2;

    public static Action<float> OnEnteringSickCloud;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(OnEnteringSickCloud != null)
            {
                OnEnteringSickCloud(reduceHealthModifier);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (OnEnteringSickCloud != null)
            {
                OnEnteringSickCloud(1);
            }
        }
    }


}

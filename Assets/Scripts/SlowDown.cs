using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SlowDown : MonoBehaviour
{
    [SerializeField] float speedModifier = 0.3f;

    public static Action<float> OnEnteringSlowZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (OnEnteringSlowZone != null)
            {
                OnEnteringSlowZone(speedModifier);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (OnEnteringSlowZone != null)
            {
                OnEnteringSlowZone(1);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreNPCController : MonoBehaviour
{

    [SerializeField] bool stationary = true;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(stationary)
        {
            
            animator.SetInteger("Animation_int", 1);
            animator.SetFloat("Speed_f", 0);
            
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorials : MonoBehaviour
{
    [SerializeField] bool tutorialsOn = true;
    
    // Start is called before the first frame update
    void Start()
    {
        if(!tutorialsOn)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OKPressed()
    {

        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}

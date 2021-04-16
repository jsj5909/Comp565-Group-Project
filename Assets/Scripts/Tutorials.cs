using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tutorials : MonoBehaviour
{
    [SerializeField] bool tutorialsOn = true;

    [SerializeField] GameObject fadePanel;


    // Start is called before the first frame update

    public static Action OkayPressed;

    void Start()
    {
        if(!tutorialsOn)
        {
            gameObject.SetActive(false);

            fadePanel.GetComponent<Fade>().StartFade();

           // OKPressed();
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
        if(OkayPressed != null)
        {
            OkayPressed();
        }
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}

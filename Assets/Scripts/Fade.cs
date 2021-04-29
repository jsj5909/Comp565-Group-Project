using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] float fadeSpeed = 0.01f;

    bool fading = false;

    float alpha = 1;

    Image fade;

    // Start is called before the first frame update
    void Start()
    {
        fade = GetComponent<Image>();

        Tutorials.OkayPressed += StartFade;

        alpha = fade.color.a;
       // Debug.LogError("Start Alpha: " + alpha.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        float alphaChange = 0;

        //Debug.Log("DeltaTime: " + Time.deltaTime.ToString());
      //  Debug.Log("Timescale: " + Time.timeScale.ToString());
        if (fading)
        {
             alpha = Mathf.Lerp(alpha,0, fadeSpeed * Time.deltaTime);

           //  Debug.Log("AlphaChange: " + alphaChange.ToString());

            // alpha -= alphaChange;

           // alpha -=  fadeSpeed;
            
            fade.color = new Color(0, 0, 0, alpha);

            
          //  Debug.Log("fade * time == " + (fadeSpeed * Time.deltaTime).ToString());
         //   Debug.LogError("Alpha: " + alpha.ToString());

            if(alpha < 0.5)
            {
                GameObject.Find("Player").GetComponent<PlayerController>().SetCanMove(true);
            }

            if (alpha < 0.01f)
            { 
                
                fading = false;

                

                //Time.timeScale = 1;
            }
        }
    }

    public void StartFade()
    {
        fading = true;
       
    }

}

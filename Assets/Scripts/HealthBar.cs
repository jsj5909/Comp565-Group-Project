using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] float healthAdjustment = -0.01f;

    [SerializeField] GameObject fill;
    [SerializeField] GameObject background;

    Slider health;

    Color greenSick;//= new Color(0, 255, 43);
    Color redHealthy; // = new Color(253, 1, 1);

    Image fillImage;
    Image backgroundImage;

    float damageModifier = 1;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Slider>();

        fillImage = fill.GetComponent<Image>();
        backgroundImage = background.GetComponent<Image>();

        redHealthy = fillImage.color;  //red by default
        greenSick = backgroundImage.color;  //green by default

        SickShopper.OnEnteringSickCloud += AdjustDamageModifier;


        FaceMask.FaceMaskPickedUp += AddMask;

    }

    // Update is called once per frame
    void Update()
    {
        health.value += healthAdjustment * damageModifier * Time.deltaTime;

        if(health.value < Mathf.Epsilon)
        {
            //Debug.Log("Sick");
            StartSickMode();
        }
    }

    void StartSickMode()
    {

        
        fillImage.color = greenSick;

       

        backgroundImage.color = Color.white;
       

        health.value = health.maxValue;


    }

    void AdjustDamageModifier(float value)
    {
        damageModifier = value;
    }

    void AddMask()
    {
        fillImage.color = redHealthy;

        backgroundImage.color = greenSick;

        health.value = health.maxValue;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] float healthAdjustment = -0.01f;

    [SerializeField] GameObject fill;
    [SerializeField] GameObject background;

    [SerializeField] GameObject deathPanel;
    [SerializeField] TextMeshProUGUI deathTypeText;
    [SerializeField] TextMeshProUGUI deathDescriptionText;

    Slider health;

    Color greenSick;//= new Color(0, 255, 43);
    Color redHealthy; // = new Color(253, 1, 1);

    Image fillImage;
    Image backgroundImage;

    float damageModifier = 1;

    bool sickMode = false;

    bool debugMode = false;

    PlayerController player;

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

        player = GameObject.Find("Player").GetComponent<PlayerController>();


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            debugMode = !debugMode;
        }
        
        
        if (player.GetCanMove() && !debugMode)
        {

            health.value += healthAdjustment * damageModifier * Time.deltaTime;

            if (health.value < Mathf.Epsilon)
            {
                if (sickMode)
                {
                    if (health.value == 0)
                    {
                        player.SetCanMove(false);
                        //  Time.timeScale = 0;
                        deathTypeText.text = "The pandemic killed you!";
                        deathDescriptionText.text = "Your mask wore out and you were overcome with illness.  Better Luck next time...";
                        deathPanel.SetActive(true);

                    }
                }
                else
                {
                    //Debug.Log("Sick");
                    StartSickMode();
                }
            }
        }
    }

    void StartSickMode()
    {
        sickMode = true;
        
        fillImage.color = greenSick;

       

        backgroundImage.color = Color.white;
       

        health.value = health.maxValue;


    }


    void AdjustDamageModifier(float value)
    {
        damageModifier = value;
    }

    void AddMask(int cost)
    {
        fillImage.color = redHealthy;

        backgroundImage.color = greenSick;

        health.value = health.maxValue;

        sickMode = false;
    }

    private void OnDestroy()
    {
        SickShopper.OnEnteringSickCloud -= AdjustDamageModifier;


        FaceMask.FaceMaskPickedUp -= AddMask;
    }
}

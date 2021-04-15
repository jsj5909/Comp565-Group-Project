using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleScreen : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] Button playButton;
    [SerializeField] Button okayButton;
    [SerializeField] Button settingsOkayButton;
    [SerializeField] Button creditsButton;
    [SerializeField] Button storyButton;

    [Header("Text")]
    [SerializeField] TextMeshProUGUI storyText;
   


    [Header("Panels")]
    [SerializeField] GameObject buttonPanel;
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject settingsPanel;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void StoryPressed()
    {
        buttonPanel.SetActive(false);

        mainPanel.SetActive(true);

        storyText.text = "The Pandemic is here!  It's Time to rush to the store for all your needed supplies.  Make sure to grab everything you need.  There is no telling when a restock will happen or if we will ever get back to normal.";
    }

    public void CreditsPressed()
    {
        buttonPanel.SetActive(false);

        mainPanel.SetActive(true);

        storyText.text = "Game by Jon, Elizabeth, Nick, and Reynaldy";
    }

    public void OkayPressed()
    {
        mainPanel.SetActive(false);
        buttonPanel.SetActive(true);
    }

    public void SettingsPressed()
    {
        settingsPanel.SetActive(true);
        buttonPanel.SetActive(false);
    }

    public void SettingsOkayPressed()
    {
        settingsPanel.SetActive(false);
        buttonPanel.SetActive(true);
    }
}

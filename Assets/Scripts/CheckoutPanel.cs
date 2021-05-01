using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CheckoutPanel : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI storeName;
    [SerializeField] TextMeshProUGUI descriptionText;

    private PlayerController player;
    
    // Start is called before the first frame update
    void Start()
    {
        descriptionText.text = "You survived another day at " + storeName.text.Substring(9);

        player = GameObject.Find("Player").GetComponent<PlayerController>();

        player.SetCanMove(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevelButtonPressed()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

       
        SceneManager.LoadScene(nextScene);
    }

}

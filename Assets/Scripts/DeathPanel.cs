using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DeathPanel : MonoBehaviour
{
    [SerializeField]
    Button reload;

    [SerializeField]
    Button mainMenu;

    [SerializeField]
    TextMeshProUGUI proceedToCheckout;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (proceedToCheckout.gameObject.activeInHierarchy)
            proceedToCheckout.gameObject.SetActive(false);

    }

    public void ReloadButtonPressed()
    {
        int activeScene = SceneManager.GetActiveScene().buildIndex;

        Time.timeScale = 1;

        SceneManager.LoadScene(activeScene);
    }

    public void MainMenuButtonPressed()
    {
        Time.timeScale = 1;
        
        SceneManager.LoadScene(0);
    }
}

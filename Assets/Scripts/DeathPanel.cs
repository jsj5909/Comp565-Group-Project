using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathPanel : MonoBehaviour
{
    [SerializeField]
    Button reload;

    [SerializeField]
    Button mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

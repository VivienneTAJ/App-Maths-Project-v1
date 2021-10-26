using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SettingsMenu settingsMenu;
    public GameObject mainMenuUI, optionsMenuUI;
    private void Start()
    {
        settingsMenu.GetCurrentSettings();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !optionsMenuUI.activeInHierarchy)
        {
            QuitGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && optionsMenuUI.activeInHierarchy)
        {
            optionsMenuUI.SetActive(false);
            mainMenuUI.SetActive(true);
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("If you're seeing this, it's working fine.");
        Application.Quit();
    }
}


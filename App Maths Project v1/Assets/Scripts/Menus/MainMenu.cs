using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SettingsMenu settingsMenu;
    public GameObject mainMenuUI, optionsMenuUI;
    public bool initialMain;
    private void Start()
    {
        settingsMenu.GetCurrentSettings();
        FindObjectOfType<AudioManager>().Play("BGM_Main");
        initialMain = false;
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
    public void QuitGame()
    {
        Debug.Log("Quitting game!");
        Application.Quit();
    }
}


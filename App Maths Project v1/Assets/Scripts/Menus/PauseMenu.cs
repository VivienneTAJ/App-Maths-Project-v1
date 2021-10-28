using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject pauseMenuUI, optionsMenuUI;
    private void Start()
    {
        gameIsPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !optionsMenuUI.activeInHierarchy)
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && optionsMenuUI.activeInHierarchy)
        {
            optionsMenuUI.SetActive(false);
            pauseMenuUI.SetActive(true);
        }
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

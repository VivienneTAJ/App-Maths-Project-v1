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
        Cursor.lockState = CursorLockMode.Confined;
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
        gameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 1;
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

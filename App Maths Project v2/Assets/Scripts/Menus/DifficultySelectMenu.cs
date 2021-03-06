using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelectMenu : MonoBehaviour //Script by: B00381904
{
    public GenerateGrid generateGrid;
    public SceneTransition sceneTransition;
    public void PlayEasy()
    {
        generateGrid.difficulty = Difficulty.Easy;
        FindObjectOfType<AudioManager>().Stop("BGM_Main");
        sceneTransition.FadeOut(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayMedium()
    {
        generateGrid.difficulty = Difficulty.Medium;
        FindObjectOfType<AudioManager>().Stop("BGM_Main");
        sceneTransition.FadeOut(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayHard()
    {
        generateGrid.difficulty = Difficulty.Hard;
        FindObjectOfType<AudioManager>().Stop("BGM_Main");
        sceneTransition.FadeOut(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelectMenu : MonoBehaviour
{
    public GenerateGrid generateGrid;
    public SceneTransition sceneTransition;
    public void PlayEasy()
    {
        generateGrid.difficulty = Difficulty.Easy;
        FindObjectOfType<AudioManager>().Stop("BGM_Main");
        FindObjectOfType<AudioManager>().Play("BGM_Level_Easy");
        sceneTransition.FadeOut(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayMedium()
    {
        generateGrid.difficulty = Difficulty.Medium;
        FindObjectOfType<AudioManager>().Stop("BGM_Main");
        FindObjectOfType<AudioManager>().Play("BGM_Level_Medium");
        sceneTransition.FadeOut(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayHard()
    {
        generateGrid.difficulty = Difficulty.Hard;
        FindObjectOfType<AudioManager>().Stop("BGM_Main");
        FindObjectOfType<AudioManager>().Play("BGM_Level_Hard");
        sceneTransition.FadeOut(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

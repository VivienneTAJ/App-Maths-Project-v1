using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToMain : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        FindObjectOfType<AudioManager>().Stop("BGM_Level_Easy");
        FindObjectOfType<AudioManager>().Stop("BGM_Level_Medium");
        FindObjectOfType<AudioManager>().Stop("BGM_Level_Hard");
    }
}

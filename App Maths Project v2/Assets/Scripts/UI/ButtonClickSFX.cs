using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSFX : MonoBehaviour
{
    public void PlayButtonSFX()
    {
        FindObjectOfType<AudioManager>().Play("SFX_Bubble");
    }
}

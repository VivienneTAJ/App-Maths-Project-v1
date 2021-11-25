using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSFX : MonoBehaviour //Script by: B00381904
{
    public void PlayButtonSFX()
    {
        FindObjectOfType<AudioManager>().Play("SFX_Bubble");
    }
}

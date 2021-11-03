using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeElapsed : MonoBehaviour
{
    public float timeElapsed = 0f;
    public TextMeshProUGUI timeText;
    private void Awake()
    {
        timeText = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        timeElapsed = Time.timeSinceLevelLoad;
        int seconds = (int)(timeElapsed % 60);
        timeElapsed /= 60;
        int minutes = (int)(timeElapsed % 60);
        timeText.text = string.Format("Time: {0}:{1}", minutes.ToString("00"), seconds.ToString("00"));
    }
}

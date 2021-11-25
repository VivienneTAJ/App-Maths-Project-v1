using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ShowHideTimer : MonoBehaviour, IPointerDownHandler //Script by: B00381904
{
    public GameObject timer, timerButton;
    public TextMeshProUGUI timeText;
    private bool timerHidden;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!timerHidden)
        {
            timer.GetComponent<CanvasRenderer>().SetAlpha(0);
            timeText.text = "Show Timer";
            timerButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(-800f, 369f, 0f);
            timer.GetComponent<RectTransform>().anchoredPosition = new Vector3(-1500f, 386f, 0f);
            timerHidden = true;
        }
        else
        {
            timer.GetComponent<CanvasRenderer>().SetAlpha(100);
            timeText.text = "Hide Timer";
            timerButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(-330f, 369f, 0f);
            timer.GetComponent<RectTransform>().anchoredPosition = new Vector3(-844f, 386f, 0f);
            timerHidden = false;
        }      
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public GridSlot gridSlot;
    public GameObject itemsParent;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.position = gridSlot.GetComponent<RectTransform>().position;
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        if (gridSlot.numberOfTiles.curNoOfTiles > 0 && rectTransform.position == gridSlot.GetComponent<RectTransform>().position)
        {
            gridSlot.numberOfTiles.curNoOfTiles--;
            gridSlot.numberOfTiles.numberText.text = $"x{gridSlot.numberOfTiles.curNoOfTiles}";
        }
        transform.SetParent(itemsParent.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (rectTransform.position != gridSlot.GetComponent<RectTransform>().position)
        {
            StartCoroutine(SmoothDamp());
        }      
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    IEnumerator SmoothDamp()
    {      
        float smoothTime = 0.2f;
        Vector3 velocity = Vector3.one;
        float smoothTimeChange = 0.0075f;

        while (rectTransform.position != gridSlot.GetComponent<RectTransform>().position)
        {
            rectTransform.position = Vector3.SmoothDamp(transform.position, gridSlot.GetComponent<RectTransform>().position, ref velocity, smoothTime);
            smoothTime -= smoothTimeChange;
            yield return null;
        }

        rectTransform.position = gridSlot.GetComponent<RectTransform>().position;
        if (gridSlot.numberOfTiles.curNoOfTiles < gridSlot.numberOfTiles.generateGrid.gridSize)
        {
            gridSlot.numberOfTiles.curNoOfTiles++;
            gridSlot.numberOfTiles.numberText.text = $"x{gridSlot.numberOfTiles.curNoOfTiles}";
            transform.SetParent(gridSlot.GetComponent<RectTransform>());
        }
    }
}

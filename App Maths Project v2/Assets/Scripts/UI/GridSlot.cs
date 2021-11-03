using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class GridSlot : MonoBehaviour, IDropHandler
{
    public NumberOfTiles numberOfTiles;
    public GameObject item;
    private void Start()
    {        
        for (int i = 0; i < numberOfTiles.generateGrid.gridSize - 1; i++)
        {
            var newItem = Instantiate(item, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            newItem.name = $"Item {i + 2}";
            newItem.transform.SetParent(transform);
        }       
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            if (numberOfTiles.curNoOfTiles < numberOfTiles.generateGrid.gridSize)
            {
                numberOfTiles.curNoOfTiles++;
                numberOfTiles.numberText.text = $"x{numberOfTiles.curNoOfTiles}";
            }
        }       
    }
}

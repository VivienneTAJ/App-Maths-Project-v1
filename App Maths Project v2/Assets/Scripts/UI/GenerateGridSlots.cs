using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGridSlots : MonoBehaviour
{
    public NumberOfTiles numberOfTiles;
    public GameObject slot;
    public GameObject item;
    public Sprite[] itemImages;
    //public Transform[] items;
    void Start()
    {
        //items = new Transform[numberOfTiles.generateGrid.gridSize * numberOfTiles.generateGrid.gridSize - numberOfTiles.generateGrid.gridSize];

        for (int i = 0; i < numberOfTiles.generateGrid.gridSize - 1; i++)
        {
            var newItemInstance = Instantiate(item, new Vector3(slot.transform.position.x, slot.transform.position.y, slot.transform.position.z), Quaternion.identity);
            newItemInstance.name = $"Item {i + 2}";
            newItemInstance.transform.SetParent(slot.transform);
            item = newItemInstance;
        }

        for (int i = 0; i < numberOfTiles.generateGrid.gridSize - 1; i++)
        {
            var newSlotInstance = Instantiate(slot, new Vector3(slot.transform.position.x, slot.transform.position.y, slot.transform.position.z), Quaternion.identity);
            newSlotInstance.name = $"Slot {i + 2}";
            newSlotInstance.transform.SetParent(transform);

            //foreach (Transform child in newSlotInstance.transform.GetComponentsInChildren<Transform>())
            //{
            //    if (child.gameObject.tag == "Item")
            //    {
            //        items[i] = child;
            //    }
            //}

            slot = newSlotInstance;
        }
    }
}

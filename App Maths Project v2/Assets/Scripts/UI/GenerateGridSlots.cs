using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGridSlots : MonoBehaviour
{   
    public NumberOfTiles numberOfTiles;
    public GameObject slot;
    void Start()
    {
        for (int i = 0; i < numberOfTiles.generateGrid.gridSize - 1; i++)
        {
            var newSlotInstance = Instantiate(slot, new Vector3(slot.transform.position.x, slot.transform.position.y - 160f, slot.transform.position.z), Quaternion.identity);
            newSlotInstance.name = $"Slot {i + 2}";
            newSlotInstance.transform.SetParent(transform);
            slot = newSlotInstance;
        }
    }
}

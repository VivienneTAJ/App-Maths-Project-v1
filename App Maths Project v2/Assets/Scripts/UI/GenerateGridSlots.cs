using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGridSlots : MonoBehaviour
{
    public NumberOfTiles numberOfTiles; //Number of tiles in grid
    public GameObject slot; //Gameobject to hold the current slot
    public GameObject item; //Gameobject to hold the current item
    public Sprite[] itemImages; //Sprite array to hold all of the item images (fish)
    //public Transform[] items; //Transform array to hold the child items of each slot (NOT WORKING)
    void Start()
    {
        //items = new Transform[numberOfTiles.generateGrid.gridSize * numberOfTiles.generateGrid.gridSize - numberOfTiles.generateGrid.gridSize];

        for (int i = 0; i < numberOfTiles.generateGrid.gridSize - 1; i++) //For loop generates the correct amount of number items in each slot
        {
            var newItemInstance = Instantiate(item, new Vector3(slot.transform.position.x, slot.transform.position.y, slot.transform.position.z), Quaternion.identity); //Instantiates items > item 1 in slot
            newItemInstance.name = $"Item {i + 2}"; //Names the instantiated item
            newItemInstance.transform.SetParent(slot.transform); //Makes the item instance a child of the item slot
            item = newItemInstance; //Sets current item to the previously instantiated item.
        }

        for (int i = 0; i < numberOfTiles.generateGrid.gridSize - 1; i++) //For loop generates the correct amount of number slots
        {
            var newSlotInstance = Instantiate(slot, new Vector3(slot.transform.position.x, slot.transform.position.y, slot.transform.position.z), Quaternion.identity); //Instantiates slots > slot 1
            newSlotInstance.name = $"Slot {i + 2}"; //Names the instantiated slot
            newSlotInstance.transform.SetParent(transform); //Makes the slot instance a child of the list contents gameobject (this)

            //foreach (Transform child in newSlotInstance.transform.GetComponentsInChildren<Transform>()) // NOT DETECTING ALL CHILDREN?
            //{
            //    if (child.gameObject.tag == "Item") //If the tag of the child is "Item" add it to the items array
            //    {
            //        items[i] = child;
            //    }
            //}

            slot = newSlotInstance; //Sets current slot to the previously instantiated slot.
        }
    }
}

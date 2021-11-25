using UnityEngine;
using UnityEngine.UI;

public class GetGridSlotChildren : MonoBehaviour //Script by: B00381904
{
    public NumberOfTiles numberOfTiles; //Number of tiles in grid
    public GameObject[] slots; //Transform array to hold the child items of each slot
    public Sprite[] itemImages; //Sprite array to hold all of the item images
    private void Start()
    {
        slots = GameObject.FindGameObjectsWithTag("Slot");

        for (int i = 0; i < slots.Length; i++)
        {
            foreach (Transform child in slots[i].transform)
            {
                if (child.tag == "Item")
                {
                    child.GetComponent<Image>().sprite = itemImages[i];
                }
            }
        }
    }
}

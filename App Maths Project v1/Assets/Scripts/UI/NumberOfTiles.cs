using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberOfTiles : MonoBehaviour
{    
    public GenerateGrid generateGrid;
    private DragDrop dragDrop;
    public TextMeshProUGUI numberText;
    private int noOfTiles;
    private void Start()
    {
        noOfTiles = generateGrid.gridSize;
        numberText = GetComponent<TextMeshProUGUI>();
        numberText.text = string.Format("x{0}", noOfTiles);
    }
    private void Update()
    {
        //if (/*dragDrop.onBeginDrag*/)
        //{
        //    noOfTiles--;
        //    numberText.text = string.Format("Time: {0}", noOfTiles);
        //}
    }
}

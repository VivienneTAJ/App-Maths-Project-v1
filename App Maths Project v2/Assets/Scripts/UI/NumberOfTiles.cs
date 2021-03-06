using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberOfTiles : MonoBehaviour //Script by: B00381904
{    
    public GenerateGrid generateGrid;
    public TextMeshProUGUI numberText;
    public int curNoOfTiles;

    private void Start()
    {
        curNoOfTiles = generateGrid.gridSize;
        numberText = GetComponent<TextMeshProUGUI>();
        numberText.text = $"x{curNoOfTiles}";
    }
}

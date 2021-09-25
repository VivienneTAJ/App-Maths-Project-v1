using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Material tileMaterial, tileMaterialOffset, tileMaterialRegion, tileMaterialRegionOffset; //Holds tile materials
    [SerializeField] private Renderer tileRenderer; //Holds tile renderer
    //[SerializeField] private GameObject tileHighlight;

    public void Init(bool isOffset, bool isRegion)
    {
        if (isRegion) //If region, set the tile material to the dark material
        {
            tileRenderer.material = isOffset ? tileMaterialRegionOffset : tileMaterialRegion;
        }
        else //Otherwise, set the tile material to the light material
        {
            tileRenderer.material = isOffset ? tileMaterialOffset : tileMaterial;
        }

        
    }

    //Going to need more mouse events for drag and drop implementation...

    void OnMouseEnter()
    {
        //tileHighlight.SetActive(true);
    }

    void OnMouseExit()
    {
        //tileHighlight.SetActive(false);
    }
}
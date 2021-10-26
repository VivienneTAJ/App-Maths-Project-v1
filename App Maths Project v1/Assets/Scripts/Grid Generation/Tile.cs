using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Material tileMaterial, tileMaterialOffset, tileMaterialRegion, tileMaterialRegionOffset; //Holds tile materials
    [SerializeField] private Renderer tileRenderer; //Holds tile renderer
    //[SerializeField] private GameObject tileHighlight;

    public void Init(bool isOffset/*, bool isOddRegion*/)
    {
        tileRenderer.material = isOffset ? tileMaterialOffset : tileMaterial;


        //if (isOddRegion) //If odd region, set the tile material to the dark material
        //{
        //    tileRenderer.material = isOffset ? tileMaterialRegionOffset : tileMaterialRegion;
        //}
        //else //Otherwise, set the tile material to the light material
        //{
        //    tileRenderer.material = isOffset ? tileMaterialOffset : tileMaterial;
        //}
    }
}
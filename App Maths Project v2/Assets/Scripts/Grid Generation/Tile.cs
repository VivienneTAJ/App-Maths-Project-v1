using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IDropHandler
{
    public Material tileMaterial, tileMaterialOffset, tileMaterialRegion, tileMaterialRegionOffset; //Holds tile materials
    public Renderer tileRenderer; //Holds tile renderer
    public void Init(bool isOffset)
    {
        tileRenderer.material = isOffset ? tileMaterialOffset : tileMaterial;
    }

    public void IsOdd(bool isOffset, bool isOddRegion)
    {
        if (isOddRegion) //If odd region, set the tile material to the dark material
        {
            tileRenderer.material = isOffset ? tileMaterialRegionOffset : tileMaterialRegion;
        }
        else //Otherwise, set the tile material to the light material
        {
            tileRenderer.material = isOffset ? tileMaterialOffset : tileMaterial;
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
        }
    }
}
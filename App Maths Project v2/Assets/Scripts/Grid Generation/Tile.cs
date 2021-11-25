using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour //Script by: B00394780
{
    public void OnCollisionEnter(Collision collision)
    {
        GameObject TileOnCollision = GameObject.Find("Logic");
        UpdateTile other = (UpdateTile)TileOnCollision.GetComponent(typeof(UpdateTile));
        //other.spawnGrid[transform.position.z, transform.position.x] = ; //This needs to update to the newly dropped number
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class GenerateGrid : MonoBehaviour
{
    public int gridSize;
    public int regionWidth, regionHeight;
    public Tile tilePrefab;
    public Transform cam;   
    public Tile[,] tiles;     
    public GameObject baseRegion;
    private GameObject[] duplicateRegions;
    public List<GameObject> allTiles;
    public Material tileMaterial, tileMaterialOffset, tileMaterialRegion, tileMaterialRegionOffset;
    public bool colIsOffset, tileIsOffset;

    void Start()
    {
        GenerateBaseRegion();
        DuplicateRegion();
        TileIsOffset();
    }

    void GenerateBaseRegion()
    {
        if (!IsPrime(gridSize) && gridSize > 1)
        {
            GetFactors(gridSize);
            tiles = new Tile[regionWidth, regionHeight];
            for (int x = 0; x < regionWidth; x++)
            {
                for (int z = 0; z < regionHeight; z++)
                {
                    var spawnedTile = Instantiate(tilePrefab, new Vector3((x * 10), 0, (z * 10)), Quaternion.identity);
                    spawnedTile.name = $"{x * 10} {z * 10}";
                    spawnedTile.transform.parent = baseRegion.transform;
                    tiles[x, z] = spawnedTile;
                    if (gridSize == 4)
                    {
                        cam.transform.position = new Vector3(-2.5f, (float)gridSize * 10, ((float)gridSize / 2 - 0.5f) * 10);
                    }
                    else if (gridSize == 6)
                    {
                        cam.transform.position = new Vector3(-1f, (float)gridSize * 10, ((float)gridSize / 2 - 0.5f) * 10);
                    }
                    else if (gridSize == 9)
                    {
                        cam.transform.position = new Vector3(2f, (float)gridSize * 10, ((float)gridSize / 2 - 0.5f) * 10);
                    }
                    else
                    {
                        cam.transform.position = new Vector3(((float)gridSize / 2 - 0.5f), (float)gridSize * 10, ((float)gridSize / 2 - 0.5f) * 10);
                    }                  
                }
            }
        }
        else
        {
            Debug.LogError("Invalid grid size!");
        }   
    }
    bool IsPrime(int gridSize)
    {
        if (gridSize == 2 || gridSize == 3)
            return true;
        if (gridSize <= 1 || gridSize % 2 == 0 || gridSize % 3 == 0)
            return false;
        for (int i = 5; i * i <= gridSize; i += 6)
        {
            if (gridSize % i == 0 || gridSize % (i + 2) == 0)
                return false;
        }
        return true;
    }
    void GetFactors(int gridSize)
    {
        for (int i = 1; i * i <= gridSize; i++)
        {
            if (gridSize % i == 0)
            {
                regionWidth = gridSize / i;
                regionHeight = i;
            }
        }
    }
    void DuplicateRegion()
    {
        int regionToFollow;
        int tilesInRow = 1, tilesInCol = 1;
        duplicateRegions = new GameObject[gridSize];
        duplicateRegions[0] = baseRegion;
        for (int i = 1; i < gridSize; i++)
        {            
            GameObject duplicateRegion = GameObject.Instantiate(baseRegion);
            duplicateRegion.name = $"Region {i + 1}";
            duplicateRegions[i] = duplicateRegion;
            duplicateRegion.transform.parent = transform;
            if (regionWidth < regionHeight)
            {
                regionToFollow = regionWidth;
            }
            else
            {
                regionToFollow = regionHeight;
            }
            if (tilesInRow < regionToFollow)
            {
                duplicateRegions[i].transform.position = new Vector3(duplicateRegions[i - 1].transform.position.x + (regionWidth * 10), 0, duplicateRegions[i - 1].transform.position.z);
                tilesInRow++;
            }
            else
            {
                duplicateRegions[i].transform.position = new Vector3(duplicateRegions[0].transform.position.x, 0, duplicateRegions[i - 1].transform.position.z + (regionHeight * 10));
                tilesInCol++;
                tilesInRow = 1;
            }
            Transform parentTransform = duplicateRegions[i].transform;
            foreach (Transform child in parentTransform)
            {
                float x = child.position.x, z = child.position.z;
                child.name = $"{x} {z}";
            }
        }
    }
    public void TileIsOffset()
    {
        allTiles = GameObject.FindGameObjectsWithTag("Tile").OrderBy((GameObject i) => i.transform.position.x).ToList();
        foreach (GameObject child in allTiles)
        {
            float x = child.transform.position.x, z = child.transform.position.z;
            if ((x / 10) % 2 == 1)
            {
                colIsOffset = true;
                tileIsOffset = ((z / 10) % 2 == 1);
            }
            else
            {
                colIsOffset = false;
                tileIsOffset = ((z / 10) % 2 == 0);
            }
            SetTileMaterials(child, tileIsOffset);
        }
    }

    public void SetTileMaterials(GameObject currentTile, bool isOffset/*, bool isOddRegion*/)
    {
        currentTile.GetComponent<MeshRenderer>().material = isOffset ? tileMaterialOffset : tileMaterial;

        //if (isOddRegion) //If odd region, set the tile material to the dark material
        //{
        //    currentTile.GetComponent<MeshRenderer>().material = isOffset ? tileMaterialRegionOffset : tileMaterialRegion;
        //}
        //else //Otherwise, set the tile material to the light material
        //{
        //    currentTile.GetComponent<MeshRenderer>().material = isOffset ? tileMaterialOffset : tileMaterial;
        //}
    }

}

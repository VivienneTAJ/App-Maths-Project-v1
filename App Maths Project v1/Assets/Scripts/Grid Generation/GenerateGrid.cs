using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    public int gridSize;
    private int totalTiles;
    private int regionWidth, regionHeight;
    public Tile tilePrefab;
    public Transform cam;
    public Tile[,] tiles;
    
    public GameObject baseRegion;
    private GameObject[] duplicateRegions;

    public bool[] isTileOffset;
    public GameObject[] allTiles;
    public GameObject gridManager;

    public Material tileMaterial, tileMaterialOffset, tileMaterialRegion, tileMaterialRegionOffset;
    public Renderer tileRenderer;

    void Start()
    {
        totalTiles = gridSize * gridSize;
        allTiles = new GameObject[totalTiles];
        isTileOffset = new bool[totalTiles];

        GenerateGridInGame();
        GetAllTiles();
        //TileIsOffset();
    }

    void GenerateGridInGame()
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
                    spawnedTile.name = $"Tile {x} {z}";

                    bool isOffset = (x + z) % 2 == 1;

                    spawnedTile.Init(isOffset);

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
            duplicateRegions = new GameObject[gridSize];
            DuplicateRegion();
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
        int tilesInRow = 1;
        int tilesInCol = 1;

        duplicateRegions[0] = baseRegion;
        for (int i = 1; i < gridSize; i++)
        {            
            GameObject duplicateRegion = GameObject.Instantiate(baseRegion);
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
        }
    }
    void GetAllTiles()
    {       
        allTiles = GameObject.FindGameObjectsWithTag("Tile");

        for (int i = 0; i < totalTiles; i++)
        {
            Debug.Log(allTiles[i]);
        }
    }

    //public void TileIsOffset()
    //{
    //    allTiles = GameObject.FindGameObjectsWithTag("Tile");
    //    bool isOffset, isOddRegion;

    //    for (int i = 0; i < totalTiles; i++)
    //    {
    //        isOffset = ((allTiles[i].transform.position.x / 10) + (allTiles[i].transform.position.z / 10)) % 2 == 1;
    //        isOddRegion = (i % 2 == 1);
    //        SetTileMaterials(isOffset, isOddRegion);
    //    }
    //}

    //public void SetTileMaterials(bool isOffset, bool isOddRegion)
    //{
    //    if (isOddRegion) //If odd region, set the tile material to the dark material
    //    {
    //        tileRenderer.material = isOffset ? tileMaterialRegionOffset : tileMaterialRegion;
    //    }
    //    else //Otherwise, set the tile material to the light material
    //    {
    //        tileRenderer.material = isOffset ? tileMaterialOffset : tileMaterial;
    //    }
    //}
}

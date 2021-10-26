using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    public int gridSize;
    private int regionWidth, regionHeight;
    public Tile tilePrefab;
    public Transform cam;
    private Tile[,] tiles;

    public GameObject baseRegion;
    private GameObject[] duplicateRegions;

    void Start()
    {     
        GenerateGridInGame();        
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
                    var isOffset = (x + z) % 2 == 1;
                    spawnedTile.Init(isOffset);
                    spawnedTile.transform.parent = baseRegion.transform;
                    tiles[x, z] = spawnedTile;
                    cam.transform.position = new Vector3(((float)gridSize / 2 - 0.5f) * 10, (float)gridSize * 10, ((float)gridSize / 2 - 0.5f) * 10);
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
}

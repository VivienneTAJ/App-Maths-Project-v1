using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private int gridSize; //Holds the grid size in tiles. One value since the grid will always be square
    [SerializeField] private int regionWidth, regionHeight; //Variables to hold the regions' width and height
    [SerializeField] private Tile tilePrefab; //Instance of the "Tile" prefab so that the tiles can be used to make the grid
    [SerializeField] private Transform cam; //The camera's current position
    private Dictionary<Vector3, Tile> tiles; //Holds all of the tiles within the grid
    #endregion

    void Start() //Could use void Awake()??? Don't think it matters right now, but may do when adding numbers to grid
    {
        GenerateGrid(); //Generating the grid on program start
    }

    void GenerateGrid() //Method to generate the grid  
    {
        if (!IsPrime(gridSize) && gridSize > 1) //If the grid size isn't a prime number or 1, generate the grid 
        {
            GetFactors(gridSize); //Determines the region size of the grid
            tiles = new Dictionary<Vector3, Tile>(); //Generates new dictionary to hold the tiles and their positions

            for (int x = 0; x < gridSize; x++)
            {
                for (int z = 0; z < gridSize; z++)
                {
                    //Have to multiply x and z by 10 to keep scaling accurate!!
                    var spawnedTile = Instantiate(tilePrefab, new Vector3((x * 10), 0, (z * 10)), Quaternion.identity); //Generate tile at position
                    spawnedTile.name = $"Tile {x} {z}"; //Sets tile name in Hierarchy

                    bool isRegion;


                    //FIX THIS!!! SMALL GRID REGIONS NOT DISPLAYING ACCURATELY
                    if (spawnedTile.transform.position.x < regionWidth && spawnedTile.transform.position.z < regionHeight) //If the spawned tile is part of the region, set region to true
                    {
                        isRegion = true;
                    }
                    else //Otherwise, set region to false
                    {
                        isRegion = false;
                    }

                    var isOffset = (x + z) % 2 == 1; //Calculate if tile is offset
                    spawnedTile.Init(isOffset, isRegion); //Calls method to set tile appearance
                    tiles[new Vector2(x, z)] = spawnedTile; //Adds the spawned tile to the tiles array
                }
            }

            //regionWidth += regionWidth;
            //regionHeight += regionHeight;

            cam.transform.position = new Vector3(((float)gridSize / 2 - 0.5f) * 10, 100, ((float)gridSize / 2 - 0.5f) * 10); //Center camera to grid position
        }
        else //Otherwise, display an error message
        {
            Debug.LogError("Invalid grid size!"); 
        }
    }
    public Tile GetTileAtPosition(Vector2 pos) //Method to get the tile at a specific position
    {
        if (tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }                     
        return null;
    }
    bool IsPrime(int gridSize) //Method to check if the grid size is a prime number
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
    void GetFactors(int gridSize) //Method to get factors of the grid size so the region size can be calculated
    {
        for (int i = 1; i * i <= gridSize; i++)
        {
            if (gridSize % i == 0)
            {
                regionWidth = (gridSize / i) * 10;
                regionHeight = i * 10;
            }            
        }
    }
}
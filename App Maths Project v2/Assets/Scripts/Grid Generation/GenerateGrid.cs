using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class GenerateGrid : MonoBehaviour //Script by: B00381904
{
    public int gridSize; //Int to hold the grid size
    public int regionWidth, regionHeight; //Ints to hold the grid region width and height respectively
    public Tile tilePrefab; //Tile variable to hold the tile prefab
    public Transform cam; //Transform variable to hold the camera's current transform within the world space  
    public Tile[,] regionTiles; //Tile array to hold all of the tiles in the current region 
    public GameObject baseRegion; //GameObject variable to hold the first region generated
    private GameObject[] duplicateRegions; //GameObject array to hold the duplicated regions
    public List<GameObject> allTiles; //GameObject list to hold all of the tiles in the current grid
    public Material tileMaterial, tileMaterialOffset, tileMaterialRegion, tileMaterialRegionOffset; //Material variables to hold all of the possible materials that a tile can have
    public Difficulty difficulty; //Difficulty variable to hold the current difficulty of the game

    public GameObject[] regions; //GameObject array to hold all of the regions in the game

    void Awake()
    {
        GetDifficulty(); //Calls the "GetDifficulty" Method
        GenerateBaseRegion(); //Calls the "GenerateBaseRegion" Method
        DuplicateRegion(); //Calls the "DuplicateRegion" Method
        RegionIsOffset(); //Calls the "RegionIsOffset" Method
    }
    void GetDifficulty() //Method to get the difficulty of the current game
    { 
        switch (difficulty) //Switch statement to check all of the possible game difficulties
        {
            case Difficulty.Easy: //If the current difficulty is easy
                gridSize = 4; //Sets the grid size to 4
                FindObjectOfType<AudioManager>().Play("BGM_Level_Easy"); //Finds the audio manager in the scene and plays the easy theme music
                cam.transform.position = new Vector3(-2.5f, (float)gridSize * 10, ((float)gridSize / 2 - 0.5f) * 10); //Sets the camera position based on the grid size
                break; //Exits the switch statement
            case Difficulty.Medium: //If the current difficulty is medium
                gridSize = 6; //Sets the grid size to 6
                FindObjectOfType<AudioManager>().Play("BGM_Level_Medium"); //Finds the audio manager in the scene and plays the medium theme music
                cam.transform.position = new Vector3(-1f, (float)gridSize * 10, ((float)gridSize / 2 - 0.5f) * 10); //Sets the camera position based on the grid size
                break; //Exits the switch statement
            case Difficulty.Hard: //If the current difficulty is hard
                gridSize = 9; //Sets the grid size to 9
                FindObjectOfType<AudioManager>().Play("BGM_Level_Hard"); //Finds the audio manager in the scene and plays the hard theme music
                cam.transform.position = new Vector3(2f, (float)gridSize * 10, ((float)gridSize / 2 - 0.5f) * 10); //Sets the camera position based on the grid size
                break; //Exits the switch statement
            default: //Default to medium difficulty if no difficulty is set
                gridSize = 6;
                FindObjectOfType<AudioManager>().Play("BGM_Level_Medium");
                cam.transform.position = new Vector3(-1f, (float)gridSize * 10, ((float)gridSize / 2 - 0.5f) * 10); //Sets the camera position based on the grid size
                break; //Exits the switch statement
        }      
        Debug.Log(difficulty); //Logs the difficulty to ensure that the correct values have been set
    }
    void GenerateBaseRegion() //Method to generate the first (base) grid region in the game
    {
        if (!IsPrime(gridSize) && gridSize > 1) //If the grid size is not a prime number and is greater than 1
        {
            GetFactors(gridSize); //Calls the "GetFactors" Method
            regionTiles = new Tile[regionWidth, regionHeight]; //Sets the size of the regionTiles array
            for (int x = 0; x < regionWidth; x++) //For loop to increment until the regionWidth is reached
            {
                for (int z = 0; z < regionHeight; z++) //For loop to increment until the regionHeight is reached
                {
                    //All x and z values multiplied by 10 so that they are scaled correctly
                    var spawnedTile = Instantiate(tilePrefab, new Vector3((x * 10), 0, (z * 10)), Quaternion.identity); //Variable to hold the newly spawned tile
                    spawnedTile.name = $"{x * 10} {z * 10}"; //Sets the spawned tile's name to its current position
                    spawnedTile.transform.parent = baseRegion.transform; //Sets the parent of the spawned tile to the base region
                    regionTiles[x, z] = spawnedTile; //Adds the spawned tile to the region tiles array              
                }
            }
        }
        else
        {
            Debug.LogError("Invalid grid size!"); //Else log an error that the grid size is invalid
        }   
    }
    bool IsPrime(int gridSize) //Method to check if the grid size is a prime number
    {
        if (gridSize == 2 || gridSize == 3)
        {
            return true; //The grid size is a prime number (invalid)
        }          
        if (gridSize <= 1 || gridSize % 2 == 0 || gridSize % 3 == 0) 
        {
            return false; //The grid size not is a prime number (valid)
        }
        for (int i = 5; i * i <= gridSize; i += 6)
        {
            if (gridSize % i == 0 || gridSize % (i + 2) == 0)
            {
                return false; //The grid size not is a prime number (valid)
            }
        }
        return true; //The grid size is a prime number (invalid)
    }
    void GetFactors(int gridSize) //Method to get all factors of the grid size (Determines region dimensions)
    {
        for (int i = 1; i * i <= gridSize; i++)
        {
            if (gridSize % i == 0) //If the grid size divided by i leaves a remainder of 0
            {
                //The values saved will be the final factors of the grid size
                regionWidth = gridSize / i; //Sets the region height to the value of the grid size divided by i
                regionHeight = i; //Sets the region height to the value of i
            }
        }
    }
    void DuplicateRegion() //Method to duplicate the base region
    {
        int regionToFollow; //Int to hold the dimension of the region to follow when positioning the regions in the scene
        int tilesInRow = 1, tilesInCol = 1; //Ints to hold the current number of tiles in a row and column respectively
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
    public void RegionIsOffset() //Method to check if the current region is offset
    //Not assigning the correct material yet
    {
        bool regionIsOffset;
        regions = GameObject.FindGameObjectsWithTag("Region");

        for (int i = 0; i < regions.Length; i++)
        {
            if (i % 2 == 1)
            {
                regionIsOffset = true;
            }
            else
            {
                regionIsOffset = false;
            }
            TileIsOffset(regionIsOffset);
        }
    }
    public void TileIsOffset(bool regionIsOffset)//Method to check if the current tile is offset
    //Not assigning the correct material yet
    {
        bool tileIsOffset;
        allTiles = GameObject.FindGameObjectsWithTag("Tile").OrderBy((GameObject i) => i.transform.position.x).ToList();
        foreach (GameObject child in allTiles)
        {
            float x = child.transform.position.x, z = child.transform.position.z;
            if ((x / 10) % 2 == 1)
            {
                tileIsOffset = ((z / 10) % 2 == 1);
            }
            else
            {
                tileIsOffset = ((z / 10) % 2 == 0);
            }
            SetTileMaterials(child, tileIsOffset, regionIsOffset);
        }
    }
    public void SetTileMaterials(GameObject currentTile, bool tileIsOffset, bool regionIsOffset) //Not assigning the correct material yet
    {

        if (!regionIsOffset) //If the current region is not offset
        {
            currentTile.GetComponent<MeshRenderer>().material = tileIsOffset ? tileMaterialRegionOffset : tileMaterialRegion; //Sets the tile material to the darker material
        }
        else
        {
            currentTile.GetComponent<MeshRenderer>().material = tileIsOffset ? tileMaterialOffset : tileMaterial; //Sets the tile material to the lighter material
        }
    }

}

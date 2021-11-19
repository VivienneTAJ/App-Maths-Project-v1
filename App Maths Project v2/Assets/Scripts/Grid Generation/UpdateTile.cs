using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTile : MonoBehaviour
{
    public int[,] spawnGrid;
    // Start is called before the first frame update
    void Start()
    {
        spawnGrid = new int[4, 4];
}
    void checkSubgrid(int i, int j)
    {
        if (spawnGrid[i, j] == spawnGrid[i+1, j] || spawnGrid[i, j] == spawnGrid[i, j+1] || spawnGrid[i, j] == spawnGrid[i+1, j+1])
        {
            if (spawnGrid[i, j+1] == spawnGrid[i+1, j] || spawnGrid[i, j+1] == spawnGrid[i+1, j+1])
            {
                if (spawnGrid[i+1, j] == spawnGrid[i+1, j+1])
                {
                    //Player needs to be notified when Sudoku is wrong
                    //Debug.Log("Sudoku is wrong");
                }

            }
        }
    }
    void checkLine(int i)
    {
        if (spawnGrid[i, 0] == spawnGrid[i, 1] || spawnGrid[i, 0] == spawnGrid[i, 2] || spawnGrid[i, 0] == spawnGrid[i, 3])
        {
            if (spawnGrid[i, 1] == spawnGrid[i, 2] || spawnGrid[i, 1] == spawnGrid[i, 3])
            {
                if (spawnGrid[i, 2] == spawnGrid[i, 3])
                {
                    //Player needs to be notified when Sudoku is wrong
                    //Debug.Log("Sudoku is wrong");
                }

            }
        }
    }
    void checkCollumn(int j)
    {
        if (spawnGrid[0, j] == spawnGrid[1, j] || spawnGrid[0, j] == spawnGrid[2, j] || spawnGrid[0, j] == spawnGrid[3, j])
        {
            if (spawnGrid[1, j] == spawnGrid[2, j] || spawnGrid[1, j] == spawnGrid[3, j])
            {
                if (spawnGrid[2, j] == spawnGrid[3, j])
                {
                    //Player needs to be notified when Sudoku is wrong
                    //Debug.Log("Sudoku is wrong");
                }

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        checkSubgrid(0, 0);
        checkSubgrid(0, 2);
        checkSubgrid(2, 0);
        checkSubgrid(2, 2);

        checkLine(0);
        checkLine(1);
        checkLine(2);
        checkLine(3);

        checkCollumn(0);
        checkCollumn(1);
        checkCollumn(2);
        checkCollumn(3);
    }
}

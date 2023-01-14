using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HexGridManager : MonoBehaviour
{
    // HexTile Gameobject Array
    public HexTile[] HexTileArray;

    // HexGrid
    private int _rows = 8;
    private int _columns = 7;
    private HexTile [,] _hexGridArray;

    void Start()
    {
        _hexGridArray = GenerateHexGrid(_rows, _columns);
        ToggleDebug(false);
    }

    void Update()
    {
        
    }

    HexTile[,] GenerateHexGrid(int rows, int columns)
    {
        int index = 0;
        // Grid is being built from top left, left to right, downwards.
        // Example: https://imgur.com/2ljonPU
        HexTile[,] hexGrid = new HexTile[rows,columns];

        for (int r = 0; r < rows; r++)
        {
            for (int q = 0; q < columns; q++)
            {
                // Set tile coords
                HexTile hexTile = HexTileArray[index];
                hexTile.SetCoords(q - Mathf.Floor(r/2),r);
                // Reference for storage: https://www.redblobgames.com/grids/hexagons/#map-storage
                hexGrid[r,q] = hexTile;
                index++;
            }
        }
        return hexGrid;
    }

    public void ToggleDebug(bool enabled)
    {
        foreach (var tile in _hexGridArray)
        {
            if(enabled)
            {
                tile.transform.Find("Canvas/CoordText").GetComponent<TMP_Text>().SetText(tile.GetCoords().x + "," + tile.GetCoords().y);
            }
            else
            {
                tile.transform.Find("Canvas/CoordText").GetComponent<TMP_Text>().SetText("");
            }
        }
    }
}

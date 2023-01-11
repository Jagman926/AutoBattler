using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HexGridManager : MonoBehaviour
{
    // HexTile
    public GameObject HexTilePrefab;

    // HexGrid
    private GameObject _hexGridObject;
    public int Rows;
    public int Columns;
    private const float TILE_SPACING = 0.5f;
    private HexTile [,] _hexGridArray;
    private Vector3 _hexGridOriginOffset;

    //Debug
    public bool EnableDebug = false;

    void Start()
    {
        _hexGridArray = GenerateHexGrid(Rows, Columns);
    }

    void Update()
    {
        
    }

    HexTile[,] GenerateHexGrid(int rows, int columns)
    {
        // Grid is being built from top left, left to right, downwards.
        // Example: https://imgur.com/2ljonPU
        HexTile[,] hexGrid = new HexTile[rows,columns];
        
        _hexGridObject = new GameObject("HexGrid");
        _hexGridObject.transform.SetParent(gameObject.transform);
        _hexGridOriginOffset = new Vector3(-columns/2, rows/2 - TILE_SPACING, 0);

        for (int r = 0; r < rows; r++)
        {
            for (int q = 0; q < columns; q++)
            {
                // If odd row, offset by half tile
                Vector3 hexTilePos = (r%2 == 0) ? new Vector3(q,-r,0) : new Vector3(q+TILE_SPACING,-r,0);
                GameObject hexTileObject = Instantiate(HexTilePrefab, _hexGridOriginOffset + hexTilePos, Quaternion.identity);
                hexTileObject.transform.SetParent(_hexGridObject.transform);
                // Set tile coords
                HexTile hexTile = hexTileObject.GetComponent<HexTile>();
                hexTile.SetCoords(q - Mathf.Floor(r/2),r);
                // Debug
                if(EnableDebug)
                {
                    hexTileObject.transform.Find("Canvas/CoordText").GetComponent<TMP_Text>().SetText(hexTile.GetCoords().x + "," + hexTile.GetCoords().y);
                }
                // Reference for storage: https://www.redblobgames.com/grids/hexagons/#map-storage
                hexGrid[r,q] = hexTile;
            }
        }
        return hexGrid;
    }
}

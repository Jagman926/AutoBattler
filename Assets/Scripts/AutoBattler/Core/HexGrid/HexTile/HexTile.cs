using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour
{
    private Vector2 HexTileCoords;

    private string HexTileCoordText;

    void Start()
    {

    }

    void Update()
    {
        
    }
    
    #region Coordinates

    public void SetCoords(Vector2 coords)
    {
        HexTileCoords = coords;
    }

    public void SetCoords(float x, float y)
    {
        HexTileCoords = new Vector2(x, y);
    }

    public Vector2 GetCoords()
    {
        return HexTileCoords;
    }
    #endregion
}

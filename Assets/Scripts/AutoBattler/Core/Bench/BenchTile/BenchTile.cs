using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchTile : MonoBehaviour
{

    private int BenchTileIndex;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    #region Index

    public void SetIndex(int index)
    {
        BenchTileIndex = index;
    }

    public int GetIndex()
    {
        return BenchTileIndex;
    }
    #endregion
}

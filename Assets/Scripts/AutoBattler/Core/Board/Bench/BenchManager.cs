using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BenchManager : MonoBehaviour
{
    // BenchTile
    public BenchTile [] BenchTileArray;

    // HexGrid
    private int _size = 9;
    private BenchTile [] _benchArray;

    void Start()
    {
        _benchArray = GenerateBenchArray(_size);
        ToggleDebug(false);
    }

    void Update()
    {
        
    }

    private BenchTile [] GenerateBenchArray(int size)
    {
        int index = 0;

        BenchTile[] benchArray = new BenchTile[size];

        for (int i = 0; i < size; i++)
        {
            // Set bench index
            BenchTile benchTile = BenchTileArray[index];
            benchTile.SetIndex(i);
            benchArray[i] = benchTile;
            index++;
        }
        return benchArray;
    }

    public void ToggleDebug(bool enabled)
    {
        foreach (var tile in _benchArray)
        {
            if(enabled)
            {
                tile.transform.Find("Canvas/IndexText").GetComponent<TMP_Text>().SetText(tile.GetIndex().ToString());
            }
            else
            {
                tile.transform.Find("Canvas/IndexText").GetComponent<TMP_Text>().SetText("");
            }
        }
    }
}

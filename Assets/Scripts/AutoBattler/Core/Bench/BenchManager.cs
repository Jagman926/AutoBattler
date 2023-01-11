using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BenchManager : MonoBehaviour
{
    // BenchTile
    public GameObject BenchTilePrefab;

    // HexGrid
    private GameObject _benchArrayObject;
    public int Size;
    private const float TILE_SPACING = .81f;
    private BenchTile [] _benchArray;
    private Vector3 _benchOriginOffset;

    //Debug
    public bool EnableDebug = false;

    void Start()
    {
        _benchArray = GenerateBenchArray(Size);
    }

    void Update()
    {
        
    }

    private BenchTile [] GenerateBenchArray(int size)
    {
        BenchTile[] benchArray = new BenchTile[size];

        _benchArrayObject = new GameObject("Bench");
        _benchArrayObject.transform.SetParent(gameObject.transform);
        _benchOriginOffset = new Vector3(-3.3f, -4.5f, 0);

        for (int i = 0; i < size; i++)
        {
            Vector3 benchTilePos = new Vector3(i*TILE_SPACING,0,0);
            GameObject benchTileObject = Instantiate(BenchTilePrefab, _benchOriginOffset + benchTilePos, Quaternion.identity);
            benchTileObject.transform.SetParent(_benchArrayObject.transform);
            // Set bench index
            BenchTile benchTile = benchTileObject.GetComponent<BenchTile>();
            benchTile.SetIndex(i);
            if(EnableDebug)
            {
                benchTileObject.transform.Find("Canvas/IndexText").GetComponent<TMP_Text>().SetText(benchTile.GetIndex().ToString());
            }
            benchArray[i] = benchTile;
        }
        return benchArray;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BenchManager : MonoBehaviour
{
    // BenchTile
    private GameObject BenchTilePrefab;

    // HexGrid
    private GameObject _benchArrayObject;
    public int Size;
    private const float TILE_SPACING = .81f;
    private BenchTile [] _benchArray;
    private Vector3 _benchOriginOffset;

    public BenchManager InitBenchManager(int size)
    {
        Size = size;
        return this;
    }

    void Awake()
    {
        BenchTilePrefab = Resources.Load("Prefabs/BenchTile") as GameObject;
    }

    void Start()
    {
        _benchArray = GenerateBenchArray(Size);
        ToggleDebug(false);
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
            benchArray[i] = benchTile;
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

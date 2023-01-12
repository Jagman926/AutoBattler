using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    private HexGridManager _hexGridManager;
    private BenchManager _benchManager;

    //Debug
    private bool _enableDebug = false;
    public bool EnableDebug = false;

    // HexGrid
    public int HexGridRows;
    public int HexGridColumns;

    // Bench
    public int BenchSize;

    void Awake()
    {
        NullCheck();
    }

    void Start()
    {
        InitHexGrid();
        InitBench();
    }

    void Update()
    {
        IsDebugEnabled();
    }

    private void NullCheck()
    {
        Debug.Assert(_benchManager == null, "[BoardManager] BenchManager is null");
        Debug.Assert(_hexGridManager == null, "[BoardManager] HexGridManager is null");
    }

    #region Init

    private void InitHexGrid()
    {
        _hexGridManager = gameObject.AddComponent<HexGridManager>().InitHexGridManager(HexGridRows, HexGridColumns);
    }

    private void InitBench()
    {
        _benchManager = gameObject.AddComponent<BenchManager>().InitBenchManager(BenchSize);
    }

    #endregion

    private void IsDebugEnabled()
    {
        if(EnableDebug != _enableDebug)
        {
            _enableDebug = EnableDebug;
            ToggleDebug(_enableDebug);
        }
    }

    public void ToggleDebug(bool enabled)
    {
        _hexGridManager.ToggleDebug(enabled);
        _benchManager.ToggleDebug(enabled);
    }
}

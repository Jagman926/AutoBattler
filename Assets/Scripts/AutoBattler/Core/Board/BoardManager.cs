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

    // Players
    private Player _homePlayer;
    private Player _awayPlayer;

    // HexGrid
    public int HexGridRows;
    public int HexGridColumns;

    // Bench
    public int BenchSize;

    void Awake()
    {
        InitComponents();
    }

    void Start()
    {

    }

    void Update()
    {
        IsDebugEnabled();
    }

    #region Init

    private void InitComponents()
    {
        InitHexGrid();
        InitBench();
    }

    private void InitHexGrid()
    {
        _hexGridManager = gameObject.AddComponent<HexGridManager>().InitHexGridManager(HexGridRows, HexGridColumns);
        Debug.Assert(_hexGridManager != null, "[BoardManager] HexGridManager is null");
    }

    private void InitBench()
    {
        _benchManager = gameObject.AddComponent<BenchManager>().InitBenchManager(BenchSize);
        Debug.Assert(_benchManager != null, "[BoardManager] BenchManager is null");
    }

    #endregion

        #region Players

    public void SetHomePlayer(Player homePlayer)
    {
        _homePlayer = homePlayer;
    }

    public Player GetHomePlayer()
    {
        return _homePlayer;
    }

    public void SetAwayPlayer(Player awayPlayer)
    {
        _awayPlayer = awayPlayer;
    }

    public Player GetAwayPlayer()
    {
        return _awayPlayer;
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

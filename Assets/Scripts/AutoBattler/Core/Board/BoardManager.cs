using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public HexGridManager _hexGridManager;
    public BenchManager _benchManagerHome;
    public BenchManager _benchManagerAway;

    //Debug
    private bool _enableDebug = false;
    public bool EnableDebug = false;

    // Players
    private Player _homePlayer;
    private Player _awayPlayer;

    void Start()
    {

    }

    void Update()
    {
        IsDebugEnabled();
    }

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
        _benchManagerHome.ToggleDebug(enabled);
        _benchManagerAway.ToggleDebug(enabled);
    }
}

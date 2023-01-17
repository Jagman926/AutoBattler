using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private RoundManager _roundManager;

    void Awake()
    {
        Init();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    #region Init

    private void Init()
    {
        InitComponents();
    }

    private void InitComponents()
    {
        InitRoundManager();
    }

    private void InitRoundManager()
    {
        _roundManager = gameObject.AddComponent<RoundManager>().Init();
        Debug.Assert(_roundManager != null, "[GameManager] RoundManager is null");
    }

    #endregion
}

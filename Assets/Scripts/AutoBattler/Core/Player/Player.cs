using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Economy
    private Economy _economy;
    
    // Health Component
    // Battle Componenet (record and streak)
    // Augment Component
    // Team Component

    void Awake()
    {
        InitComponents();
    }

    void Start()
    {

    }

    void Update()
    {
        
    }

    #region Init

    private void InitComponents()
    {
        InitEconomy();
    }

    private void InitEconomy()
    {
        _economy = gameObject.AddComponent<Economy>().InitEconomy(0);
        Debug.Assert(_economy == null, "[Player] Economy is null");
    }

    #endregion
}

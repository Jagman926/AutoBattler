using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Economy
    private Economy _economy;
    // Level
    private Experience _experience;
    // Health Component
    private Health _health;
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
        InitHealth();
        InitExperience();
    }

    private void InitEconomy()
    {
        _economy = gameObject.AddComponent<Economy>().Init(0);
        Debug.Assert(_economy == null, "[Player] Economy is null");
    }

    private void InitHealth()
    {
        _health = gameObject.AddComponent<Health>().Init();
        Debug.Assert(_health == null, "[Player] Health is null");
    }

    private void InitExperience()
    {
        _experience = gameObject.AddComponent<Experience>().Init();
        Debug.Assert(_experience == null, "[Player] Experience is null");
    }

    #endregion
}

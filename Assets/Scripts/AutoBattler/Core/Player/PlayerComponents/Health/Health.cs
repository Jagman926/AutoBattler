using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : PlayerComponent
{
    private int _health;
    private const int STARTING_HEALTH = 100;
    private int _healthMax;

    #region Init

    public Health Init()
    {
        _health = STARTING_HEALTH;
        _healthMax = STARTING_HEALTH;
        return this;
    }
    #endregion

    #region Set/Get

    private void SetHealth(int health)
    {
        _health = health;
    }

    public int GetHealth()
    {
        return _health;
    }

    public void SetHealthMax(int max)
    {
        _healthMax = max;
    }

    public int GetHealthMax()
    {
        return _healthMax;
    }
    #endregion

    #region Health Adjusters

    public void GainHealth(int gain)
    {
        _health = Mathf.Min(_health+gain, _healthMax);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

    public void KillPlayer(bool perfectLethal = false)
    {
        if(perfectLethal)
        {
            TakeDamage(_health);
        }
        else
        {
            TakeDamage(_healthMax);
        }
    }

    #endregion

    #region Rounds

    public override void OnRoundStart()
    {

    }

    public override void OnPreperationStart()
    {

    }

    public override void OnPreperationEnd()
    {
        
    }

    #endregion
}

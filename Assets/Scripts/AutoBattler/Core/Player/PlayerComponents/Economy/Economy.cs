using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Economy : PlayerComponent
{
    private int _gold;

    // Income
    private int _passiveIncome = 5;
    // Interest
    private int _interestIncrement = 10;
    private int _interestMax = 5;
    
    // Streak
    private int _streak2to3 = 1;
    private int _streak4 = 2;
    private int _streak5Plus = 3;

    public Economy Init(int startingGold)
    {
        _gold = startingGold;
        return this;
    }

    #region Gold

    public void AddGold(int amount)
    {
        _gold += amount;
    }

    public void SubtractGold(int amount)
    {
        _gold -= amount;
    }

    #endregion

    #region Calculate Income

    public int CalculatePassiveIncome()
    {
        return _passiveIncome;
    }

    public int CalculateInterestIncome()
    {
        return Mathf.Min(_gold % _interestIncrement, _interestMax);
    }

    public int CalculateStreakIncome(int streak)
    {
        streak = Mathf.Abs(streak);

        // 0-1 = 0 Gold
        if(streak < 2)
        {
            return 0;
        }
        // 2-3 = 1 Gold
        else if(streak < 4)
        {
            return _streak2to3;
        }
        // 4 = 2 Gold
        else if (streak < 5)
        {
            return _streak4;
        }
        // 5+ = 3 Gold
        else
        {
            return _streak5Plus;
        }
    }

    #endregion

    #region Rounds

    public override void OnRoundStart()
    {

    }

    public override void OnPreperationStart()
    {
        AddGold(_passiveIncome);
    }

    public override void OnPreperationEnd()
    {
        
    }

    #endregion
}

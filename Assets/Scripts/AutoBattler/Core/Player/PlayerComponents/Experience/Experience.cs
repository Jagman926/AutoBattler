using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : PlayerComponent
{
    private int _level;
    private int _experience;

    // Experience generation
    private int _passiveExperience = 2;
    private int _boughtExperience = 4;

    // Level Requirements
    private const int LEVEL_COUNT = 10;
    private int _levelMax = 9;
    private int [] _levelRequirements;
    private const int LEVEL_1_REQUIREMENT = 2;
    private const int LEVEL_2_REQUIREMENT = 2;
    private const int LEVEL_3_REQUIREMENT = 2;
    private const int LEVEL_4_REQUIREMENT = 6;
    private const int LEVEL_5_REQUIREMENT = 10;
    private const int LEVEL_6_REQUIREMENT = 20;
    private const int LEVEL_7_REQUIREMENT = 36;
    private const int LEVEL_8_REQUIREMENT = 56;
    private const int LEVEL_9_REQUIREMENT = 80;
    private const int LEVEL_10_REQUIREMENT = 100;

    void Awake()
    {
        InitLevelRequirements();
    }

    #region Init

    public Experience Init()
    {
        _level = 0;
        _experience = 0;
        return this;
    }

    private void InitLevelRequirements()
    {
        _levelRequirements = new int [LEVEL_COUNT];
        _levelRequirements[0] = 0;
        _levelRequirements[1] = LEVEL_1_REQUIREMENT;
        _levelRequirements[2] = LEVEL_2_REQUIREMENT;
        _levelRequirements[3] = LEVEL_3_REQUIREMENT;
        _levelRequirements[4] = LEVEL_4_REQUIREMENT;
        _levelRequirements[5] = LEVEL_5_REQUIREMENT;
        _levelRequirements[6] = LEVEL_6_REQUIREMENT;
        _levelRequirements[7] = LEVEL_7_REQUIREMENT;
        _levelRequirements[8] = LEVEL_8_REQUIREMENT;
        _levelRequirements[9] = LEVEL_9_REQUIREMENT;
        _levelRequirements[10] = LEVEL_10_REQUIREMENT;
    }

    #endregion

    #region Get/Set 

    public int GetLevel()
    {
        return _level;
    }

    public int GetExperience()
    {
        return _experience;
    }

    private void GainExperience(int gain)
    {
        _experience += gain;
        CalculateLevelAndExperience();
    }

    public void BuyExperience()
    {
        GainExperience(_boughtExperience);
    }

    #endregion

    #region Calculate Level/Experience
    
    private void CalculateLevelAndExperience()
    {
        if(_level == _levelMax)
        {
            return;
        }

        int nextLevelRequirment = _levelRequirements[_level+1];
        if(_experience >= nextLevelRequirment)
        {
            _experience -= nextLevelRequirment;
            _level++;
        }
    }

    #endregion

    #region Rounds

    public override void OnRoundStart()
    {

    }

    public override void OnRoundEnd()
    {
        
    }

    public override void OnPreparationStart()
    {
        GainExperience(_passiveExperience);
    }

    public override void OnPreparationEnd()
    {
        
    }

    #endregion
}

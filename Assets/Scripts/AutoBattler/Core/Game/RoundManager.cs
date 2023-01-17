using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private int _stage;
    private int _round;

    // Rounds
    private static int STARTING_ROUND = 0;
    private static int STARTING_STAGE = 1;
    private static int STAGE_1_ROUNDS = 4;
    private static int STAGE_ROUNDS = 7;

    // Round Type
    public enum RoundType
    {
        Null = 0,
        Player,
        Neutral,
        Carousel
    }

    // Stage Array
    private RoundType [] _stage1Array;
    private RoundType [] _stageArray;

    // Round Delegates
    public delegate void StartRoundDelegate();
    public static event StartRoundDelegate OnRoundStart;
    public delegate void EndRoundDelegate();
    public static event EndRoundDelegate OnRoundEnd;
    public delegate void StartPreparationDelegate();
    public static event StartPreparationDelegate OnPreparationStart;
    public delegate void EndPreparationDelegate();
    public static event EndPreparationDelegate OnPreparationEnd;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    #region Init

    public RoundManager Init()
    {
        _stage = STARTING_STAGE;
        _round = STARTING_ROUND;
        return this;
    }

    private void CreateRoundArray()
    {
        // Stage 1 Array
        _stage1Array = new RoundType [STAGE_1_ROUNDS];
        _stage1Array[0] = RoundType.Carousel;
        _stage1Array[1] = RoundType.Neutral;
        _stage1Array[2] = RoundType.Neutral;
        _stage1Array[3] = RoundType.Neutral;

        // Stage Array
        _stageArray = new RoundType [STAGE_ROUNDS];
        _stageArray[0] = RoundType.Player;
        _stageArray[1] = RoundType.Player;
        _stageArray[2] = RoundType.Player;
        _stageArray[3] = RoundType.Carousel;
        _stageArray[4] = RoundType.Player;
        _stageArray[5] = RoundType.Player;
        _stageArray[6] = RoundType.Neutral;
    }

    #endregion

    #region Set/Get

    public int GetStage()
    {
        return _stage;
    }

    public int GetRound()
    {
        return _round;
    }

    #endregion

    #region Calculate Stage/Round

    private void IncrementRound()
    {
        _round++;
        ClaculateStageAndRound();
    }

    private void ClaculateStageAndRound()
    {
        if(_stage == 1)
        {
            if(_round >= STAGE_1_ROUNDS)
            {
                _round -= STAGE_1_ROUNDS;
                _stage++;
            }
        }
        else
        {
            if(_round >= STAGE_ROUNDS)
            {
                _round -= STAGE_ROUNDS;
                _stage++;
            }
        }
    }

    #endregion

    #region Rounds

    // Rounds
    public void StartRound()
    {
        OnRoundStart.Invoke();
    }

    public void EndRound()
    {
        OnRoundEnd.Invoke();
    }

    public void StartPreparation()
    {
        OnPreparationStart.Invoke();
    }

    public void EndPreparation()
    {
        OnPreparationEnd.Invoke();
    }

    #endregion
}

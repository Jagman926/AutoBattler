using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerComponent : MonoBehaviour
{
    void OnEnable()
    {
        RoundManager.OnRoundStart += OnRoundStart;
        RoundManager.OnRoundEnd += OnRoundEnd;
        RoundManager.OnPreparationStart += OnPreparationStart;
        RoundManager.OnPreparationEnd += OnPreparationEnd;
    }

    void OnDisable()
    {
        RoundManager.OnRoundStart -= OnRoundStart;
        RoundManager.OnRoundEnd -= OnRoundEnd;
        RoundManager.OnPreparationStart -= OnPreparationStart;
        RoundManager.OnPreparationEnd -= OnPreparationEnd;
    }

    public abstract void OnRoundStart();
    public abstract void OnRoundEnd();
    public abstract void OnPreparationStart();
    public abstract void OnPreparationEnd();
}

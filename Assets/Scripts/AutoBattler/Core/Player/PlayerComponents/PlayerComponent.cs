using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerComponent : MonoBehaviour
{
    public abstract void OnRoundStart();
    public abstract void OnPreperationStart();
    public abstract void OnPreperationEnd();
}

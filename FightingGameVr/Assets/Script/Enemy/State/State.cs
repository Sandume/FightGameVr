using UnityEngine;

public abstract class State 
{
    public abstract void EnterState(StateManager enemy);
    public abstract void UpdateCurrentState(StateManager enemy);
}

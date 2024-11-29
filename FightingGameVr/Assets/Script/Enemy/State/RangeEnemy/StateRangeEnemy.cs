using UnityEngine;

public abstract class StateRangeEnemy
{
    public abstract void EnterState(StateManagerRangeEnemy enemy);
    public abstract void UpdateCurrentState(StateManagerRangeEnemy enemy);
}

using UnityEngine;

public abstract class StateMeleeEnemy
{
    public abstract void EnterState(StateManagerMeleeEnemy enemy);
    public abstract void UpdateCurrentState(StateManagerMeleeEnemy enemy);
}

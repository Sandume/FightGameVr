using UnityEngine;

public class IdleState : State
{
    public override void EnterState(StateManager enemy)
    {
       
    }

    public override void UpdateCurrentState(StateManager enemy)
    {
        enemy.SwitchState(enemy.runState);
    }
}

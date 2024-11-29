using UnityEngine;

public class IdleStateRangeEnemy : StateRangeEnemy
{
    public override void EnterState(StateManagerRangeEnemy enemy)
    {
       
    }

    public override void UpdateCurrentState(StateManagerRangeEnemy enemy)
    {
        enemy.SwitchState(enemy.runState);
    }
}

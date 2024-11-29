using UnityEngine;

public class IdleStateMeleeEnemy : StateMeleeEnemy
{
    public override void EnterState(StateManagerMeleeEnemy enemy)
    {
       
    }

    public override void UpdateCurrentState(StateManagerMeleeEnemy enemy)
    {
        enemy.SwitchState(enemy.runState);
    }
}

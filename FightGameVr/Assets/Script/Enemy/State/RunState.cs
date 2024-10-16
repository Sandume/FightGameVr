using UnityEngine;

public class RunState : State
{
    public override void EnterState(StateManager enemy)
    {
        
    }

    public override void UpdateCurrentState(StateManager enemy)
    {
        enemy.agent.SetDestination(enemy.playerTransform.position);
        if (Vector3.Distance(enemy.transform.position, enemy.playerTransform.position)< enemy.stat.range)
        {
            enemy.SwitchState(enemy.attackState);
        }
    }
}

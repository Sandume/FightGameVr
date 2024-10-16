using UnityEngine;

public class RunState : State
{
    public override void EnterState(StateManager enemy)
    {
        
    }

    public override void UpdateCurrentState(StateManager enemy)
    {
       
        enemy.agent.SetDestination(Vector3.zero);
    }
}

using UnityEngine;

public class AttackState : State
{
    public override void EnterState(StateManager enemy)
    {
       
    }

    public override void UpdateCurrentState(StateManager enemy)
    {
        if (Vector3.Distance(enemy.playerTransform.position, enemy.transform.position) < enemy.stat.range) 
        {
        }
    }
}

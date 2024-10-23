using UnityEngine;

public class AttackState : State
{
    public override void EnterState(StateManager enemy)
    {
        Debug.Log("AttackState");
    }

    public override void UpdateCurrentState(StateManager enemy)
    {
        if (Vector3.Distance(enemy.playerTransform.position, enemy.transform.position) < enemy.stat.range) 
        { }
    }
}

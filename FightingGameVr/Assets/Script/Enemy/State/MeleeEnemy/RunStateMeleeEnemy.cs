using UnityEngine;
using UnityEngine.AI;

public class RunStateMeleeEnemy : StateMeleeEnemy
{

    public override void EnterState(StateManagerMeleeEnemy enemy)
    {
     
        enemy.animator.SetBool("IsRunning", true);
    }

    public override void UpdateCurrentState(StateManagerMeleeEnemy enemy)
    {
        enemy.agent.SetDestination(enemy.playerTransform.position);
        if (Vector3.Distance(enemy.agent.pathEndPosition, enemy.transform.position) <= enemy.stat.range)
        {
            enemy.animator.SetBool("IsRunning", false);

                enemy.SwitchState(enemy.attackState);
            
        }
    }

    
}

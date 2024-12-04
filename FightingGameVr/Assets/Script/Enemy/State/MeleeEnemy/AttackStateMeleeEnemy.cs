using UnityEngine;

public class AttackStateMeleeEnemy : StateMeleeEnemy
{
    private float timerAnimationAttack;
    public override void EnterState(StateManagerMeleeEnemy enemy)
    {
        enemy.animator.SetBool("IsAttacking", true);
        timerAnimationAttack = 0f;
        enemy.transform.LookAt(enemy.playerTransform);
    }

    public override void UpdateCurrentState(StateManagerMeleeEnemy enemy)
    {
        timerAnimationAttack += Time.deltaTime;
        // 1 = duration of attack animation
        if (timerAnimationAttack >= 1.5f)
        {
            enemy.animator.SetBool("IsAttacking", false);
            if (Vector3.Distance(enemy.playerTransform.position, enemy.transform.position) < enemy.stat.range)
            {
                enemy.SwitchState(enemy.attackState);
            }
            else
            {
                enemy.SwitchState(enemy.runState);
            }
        }
    }
}

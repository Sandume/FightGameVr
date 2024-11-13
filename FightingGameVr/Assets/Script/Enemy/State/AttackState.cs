using UnityEngine;

public class AttackState : State
{
    private float timerAnimationAttack;
    public override void EnterState(StateManager enemy)
    {
        enemy.animator.SetBool("IsAttackingDistance", true);
        timerAnimationAttack = 0f;
        enemy.transform.LookAt(enemy.playerTransform);
    }

    public override void UpdateCurrentState(StateManager enemy)
    {
        timerAnimationAttack += Time.deltaTime;
        // 1 = duration of attack animation
        if (timerAnimationAttack >= 1f)
        {
            enemy.Attack();
            enemy.SwitchState(enemy.attackState);
        }
    }
}

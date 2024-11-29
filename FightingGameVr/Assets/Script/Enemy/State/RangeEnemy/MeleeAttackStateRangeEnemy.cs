using UnityEngine;

public class MeleeAttackStateRangeEnemy : StateRangeEnemy
{
    private float timerAnimationAttack;
    public override void EnterState(StateManagerRangeEnemy enemy)
    {
        enemy.animator.SetBool("IsAttackingMelee", true);
        timerAnimationAttack = 0f;
    }

    public override void UpdateCurrentState(StateManagerRangeEnemy enemy)
    {
        timerAnimationAttack += Time.deltaTime; 

        // 1 = duration of attack animation
        if (timerAnimationAttack >= 1.433f)
        { 
            enemy.isFleeing = true;
            enemy.animator.SetBool("IsAttackingMelee", false);
            enemy.SwitchState(enemy.runState);
        }
    }
}

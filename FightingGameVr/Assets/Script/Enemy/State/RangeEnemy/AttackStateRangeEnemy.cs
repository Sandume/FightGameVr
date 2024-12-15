using UnityEngine;

public class AttackStateRangeEnemy : StateRangeEnemy
{
    private float timerAnimationAttack;
    public override void EnterState(StateManagerRangeEnemy enemy)
    {
        enemy.animator.SetBool("IsAttackingDistance", true);
        timerAnimationAttack = 0f;
        enemy.transform.LookAt(enemy.playerTransform);
    }

    public override void UpdateCurrentState(StateManagerRangeEnemy enemy)
    {
        timerAnimationAttack += Time.deltaTime;
        // 1 = duration of attack animation
        if (timerAnimationAttack >= 1.033f)
        {
            enemy.Attack();
            enemy.animator.SetBool("IsAttackingDistance", false);
            if (Vector3.Distance(enemy.playerTransform.position, enemy.transform.position)< enemy.stat.range)
            {
                enemy.SwitchState(enemy.meleeAttackState);
            }
            else if (Random.Range(0, 4) == 0)
            {
                enemy.SwitchState(enemy.crouchState);
            }
            else
            {
                enemy.SwitchState(enemy.attackState);
            }
            
           
        }
    }
}

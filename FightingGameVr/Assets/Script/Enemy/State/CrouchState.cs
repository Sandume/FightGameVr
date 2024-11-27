using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class CrouchState : State
{
    enum StateCrounch
    {
        Crouch,
        Idle,
        Stand
    }
    StateCrounch currentState;
    private float timerAnimation;
    private float maxTimeIdle;

    public override void EnterState(StateManager enemy)
    {
        enemy.animator.SetBool("IsCrouching", true);
        timerAnimation = 0f;
        currentState = StateCrounch.Crouch;
        maxTimeIdle = 0f;
    }

    public override void UpdateCurrentState(StateManager enemy)
    {
        timerAnimation += Time.deltaTime;

        switch (currentState)
        {
            case StateCrounch.Crouch:
                // 0.933f = duration of crouch animation
                if (timerAnimation >= 0.933f)
                {
                    enemy.animator.SetBool("IsCrouching", false);
                    currentState = StateCrounch.Idle;
                    timerAnimation = 0f;
                    maxTimeIdle = Random.Range(1f, 5f);
                }
                break;
            case StateCrounch.Idle:
                if (timerAnimation >= maxTimeIdle)
                {
                    enemy.animator.SetBool("IsCrouching", true);
                    currentState = StateCrounch.Stand;
                    timerAnimation = 0f;
                }
                break;
            case StateCrounch.Stand:
                if (timerAnimation >= 0.933f)
                {
                    enemy.animator.SetBool("IsCrouching", false);

                    enemy.SwitchState(enemy.attackState);
                }
                break;
            default:
                break;
        }

    }
}

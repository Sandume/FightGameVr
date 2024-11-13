using UnityEngine;
using UnityEngine.AI;

public class RunState : State
{
    Vector3 destination;
    public override void EnterState(StateManager enemy)
    {
        destination = SearchCover(enemy);
        enemy.agent.SetDestination(destination);
        enemy.animator.SetBool("IsRunning", true);
    }

    public override void UpdateCurrentState(StateManager enemy)
    {
        if (Vector3.Distance(enemy.agent.pathEndPosition, enemy.transform.position) <= 1.05f)
        {
            enemy.animator.SetBool("IsRunning", false);
            enemy.SwitchState(enemy.attackState);
        }
    }

    Vector3 SearchCover(StateManager enemy)
    {
        float lenght = float.MaxValue;
        Vector3 nearestCoverPoint = Vector3.zero;
        foreach (var actualCoverPoint in GameManager.Instance.coverPoint)
        {
            float distance = Vector3.Distance(actualCoverPoint, enemy.transform.position);
            if (distance < lenght)
            {
                lenght = distance;
                nearestCoverPoint = actualCoverPoint;
            }
        }
        if (Vector3.Distance(enemy.playerTransform.position, enemy.transform.position) < lenght)
        {
            enemy.SwitchState(enemy.attackState);
            return enemy.transform.position;
        }
        return nearestCoverPoint;
    }
}

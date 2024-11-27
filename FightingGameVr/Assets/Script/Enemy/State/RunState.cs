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
            if (Random.Range(0, 1) == 0)
            {
                enemy.SwitchState(enemy.crouchState);
            }
            else
            {
                enemy.SwitchState(enemy.attackState);
            }
        }
    }

    Vector3 SearchCover(StateManager enemy)
    {
        if (enemy.isFleeing)
        {
            enemy.coverPointUsed.isOccupied = false;
            float lenght = float.MinValue;
            Vector3 furthestCoverPoint = Vector3.zero;
            foreach (var actualCoverPoint in GameManager.Instance.coverPoint)
            {
                if (!actualCoverPoint.isOccupied)
                {
                    float distance = Vector3.Distance(actualCoverPoint.position, enemy.transform.position);
                    if (distance > lenght)
                    {
                        lenght = distance;
                        furthestCoverPoint = actualCoverPoint.position;
                        enemy.coverPointUsed = actualCoverPoint;
                    }
                }
            }
            enemy.coverPointUsed.isOccupied = true;
            enemy.isFleeing = false;
            return furthestCoverPoint;
        }
        else 
        { 
        float lenght = float.MaxValue;
        Vector3 nearestCoverPoint = Vector3.zero;
        foreach (var actualCoverPoint in GameManager.Instance.coverPoint)
        {
            if (!actualCoverPoint.isOccupied)
            {
                float distance = Vector3.Distance(actualCoverPoint.position, enemy.transform.position);
                if (distance < lenght)
                {
                    lenght = distance;
                    nearestCoverPoint = actualCoverPoint.position;
                    enemy.coverPointUsed = actualCoverPoint;
                }
            }
        }
        enemy.coverPointUsed.isOccupied = true;
        if (Vector3.Distance(enemy.playerTransform.position, enemy.transform.position) < lenght)
        {
            enemy.coverPointUsed.isOccupied = false;
            enemy.SwitchState(enemy.attackState);
            return enemy.transform.position;
        }
        return nearestCoverPoint;
        }
    }
}

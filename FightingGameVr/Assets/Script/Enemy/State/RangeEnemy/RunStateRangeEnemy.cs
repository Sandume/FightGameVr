using UnityEngine;
using UnityEngine.AI;

public class RunStateRangeEnemy : StateRangeEnemy
{
    Vector3 destination;
    public override void EnterState(StateManagerRangeEnemy enemy)
    {
        destination = SearchCover(enemy);
        enemy.agent.SetDestination(destination);
        enemy.animator.SetBool("IsRunning", true);
    }

    public override void UpdateCurrentState(StateManagerRangeEnemy enemy)
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

    Vector3 SearchCover(StateManagerRangeEnemy enemy)
    {
        if (enemy.idCoverPointUsed != -1)
        {
            GameManager.Instance.coverPoint[enemy.idCoverPointUsed].isOccupied = false;
        }
        if (enemy.isFleeing)
        {
            float lenght = float.MinValue;
            Vector3 furthestCoverPoint = Vector3.zero;
            for (int i =0;i< GameManager.Instance.coverPoint.Count;i++)
            {
                if (!GameManager.Instance.coverPoint[i].isOccupied)
                {
                    float distance = Vector3.Distance(GameManager.Instance.coverPoint[i].position, enemy.transform.position);
                    if (distance > lenght)
                    {
                        lenght = distance;
                        furthestCoverPoint = GameManager.Instance.coverPoint[i].position;
                        enemy.idCoverPointUsed = i;
                    }
                }
            }
            GameManager.Instance.coverPoint[enemy.idCoverPointUsed].isOccupied = true;
            enemy.isFleeing = false;
            return furthestCoverPoint;
        }
        else
        {
            float lenght = float.MaxValue;
            Vector3 nearestCoverPoint = Vector3.zero;
            for (int i = 0; i < GameManager.Instance.coverPoint.Count; i++)
            {
                if (!GameManager.Instance.coverPoint[i].isOccupied)
                {
                    float distance = Vector3.Distance(GameManager.Instance.coverPoint[i].position, enemy.transform.position);
                    if (distance < lenght)
                    {
                        lenght = distance;
                        nearestCoverPoint = GameManager.Instance.coverPoint[i].position;
                        enemy.idCoverPointUsed = i;
                    }
                }
            }
            GameManager.Instance.coverPoint[enemy.idCoverPointUsed].isOccupied = true;

            //if (Vector3.Distance(enemy.playerTransform.position, enemy.transform.position) < lenght)
            //{
            //    GameManager.Instance.coverPoint[enemy.idCoverPointUsed].isOccupied = true;
            //    enemy.SwitchState(enemy.attackState);
            //    return enemy.transform.position;
            //}
            return nearestCoverPoint;
        }
    }
}

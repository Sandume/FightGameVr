using UnityEngine;

public class AttackState : State
{
    public override void EnterState(StateManager enemy)
    {
        Debug.Log("AttackState");
    }

    public override void UpdateCurrentState(StateManager enemy)
    {
        throw new System.NotImplementedException();
    }
}

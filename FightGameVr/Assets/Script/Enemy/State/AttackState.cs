using UnityEngine;

public class AttackState : State
{
    public override void EnterState(StateManager enemy)
    {
        Debug.Log("ROOOOOAR");
    }

    public override void UpdateCurrentState(StateManager enemy)
    {
        throw new System.NotImplementedException();
    }
}

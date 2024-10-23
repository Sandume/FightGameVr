using UnityEngine;
using UnityEngine.AI;

public class StateManager : MonoBehaviour
{

    State currentState;
    public RunState runState = new RunState();
    public IdleState idleState = new IdleState();
    public AttackState attackState = new AttackState();
    public SO_EnemyStat stat;


    [HideInInspector] public int currentHp;
    [HideInInspector] public NavMeshAgent agent;

    public Transform playerTransform;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentHp = stat.maxHp;
        currentState = idleState;

        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateCurrentState(this);
    }

    public void SwitchState (State state)
    {
        currentState = state;
        state.EnterState(this);
    }
}

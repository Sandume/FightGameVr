using UnityEngine;
using UnityEngine.AI;

public class StateManagerMeleeEnemy : MonoBehaviour , IDamageble
{

    StateMeleeEnemy currentState;
    public RunStateMeleeEnemy runState = new RunStateMeleeEnemy();
    public IdleStateMeleeEnemy idleState = new IdleStateMeleeEnemy();
    public AttackStateMeleeEnemy attackState = new AttackStateMeleeEnemy();
    public SO_EnemyStat stat;

    [HideInInspector] public Animator animator;
    [HideInInspector] public int currentHp;
    [HideInInspector] public NavMeshAgent agent;

    public Transform playerTransform;

   private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentHp = stat.maxHp;
        currentState = idleState;
        animator = GetComponentInChildren<Animator>();
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateCurrentState(this);
        CheckDeath();
    }

    public void SwitchState (StateMeleeEnemy state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public void Hit(int damage)
    {
        currentHp -= damage;
    }

    public void CheckDeath() 
    {
        if(currentHp <= 0) 
        {
            Destroy(gameObject);
        }
    }
}

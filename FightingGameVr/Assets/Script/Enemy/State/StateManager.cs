using UnityEngine;
using UnityEngine.AI;

public class StateManager : MonoBehaviour , IDamageble
{

    State currentState;
    public RunState runState = new RunState();
    public IdleState idleState = new IdleState();
    public AttackState attackState = new AttackState();
    public SO_EnemyStat stat;

    [HideInInspector] public Animator animator;
    [HideInInspector] public int currentHp;
    [HideInInspector] public NavMeshAgent agent;

    public Transform playerTransform;
    [SerializeField] private GameObject arrowPrefabs;
    [SerializeField] private Transform arrowLunchTransform;



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

    public void SwitchState (State state)
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

    public void Attack()
    {
        Instantiate(arrowPrefabs, arrowLunchTransform.position, arrowLunchTransform.rotation);
    }
}

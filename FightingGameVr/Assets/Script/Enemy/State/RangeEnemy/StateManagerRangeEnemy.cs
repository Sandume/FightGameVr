using UnityEngine;
using UnityEngine.AI;

public class StateManagerRangeEnemy : MonoBehaviour , IDamageble
{

    StateRangeEnemy currentState;
    public RunStateRangeEnemy runState = new RunStateRangeEnemy();
    public IdleStateRangeEnemy idleState = new IdleStateRangeEnemy();
    public AttackStateRangeEnemy attackState = new AttackStateRangeEnemy();
    public CrouchStateRangeEnemy crouchState = new CrouchStateRangeEnemy();
    public MeleeAttackStateRangeEnemy meleeAttackState = new MeleeAttackStateRangeEnemy();
    public SO_EnemyStat stat;

    [HideInInspector] public Animator animator;
    [HideInInspector] public int currentHp;
    [HideInInspector] public NavMeshAgent agent;

    public Transform playerTransform;
    [SerializeField] private GameObject arrowPrefabs;
    [SerializeField] private Transform arrowLunchTransform;

    public GameManager.CoverPoint coverPointUsed;
    public bool isFleeing;
    
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
        //Debug.Log(currentState);
        currentState.UpdateCurrentState(this);
        CheckDeath();
    }

    public void SwitchState (StateRangeEnemy state)
    {
        Debug.Log(state);
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

    //Obligatoire de le laisser ici pour le instantiate (monobehavior)
    public void Attack()
    {
        Instantiate(arrowPrefabs, arrowLunchTransform.position, arrowLunchTransform.rotation);
    }
}

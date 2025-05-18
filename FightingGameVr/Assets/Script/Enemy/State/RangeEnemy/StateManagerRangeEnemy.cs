using UnityEngine;
using UnityEngine.AI;

public class StateManagerRangeEnemy : MonoBehaviour, IDamageble
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
    [HideInInspector] public Transform playerTransform;

    [SerializeField] private GameObject arrowPrefabs;
    [SerializeField] private Transform arrowLunchTransform;
    [SerializeField] public float rotationSpeed = 5;

    public int idCoverPointUsed = -1;
    public bool isFleeing;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentHp = stat.maxHp;
        currentState = idleState;
        animator = GetComponentInChildren<Animator>();
        currentState.EnterState(this);
        //A changer pour que ca soit plus scalable
        playerTransform = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        //Debug.Log(currentState);
        currentState.UpdateCurrentState(this);
        CheckDeath();
    }

    public void SwitchState(StateRangeEnemy state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public void Hit(int damage)
    {
        currentHp -= damage;
        animator.SetTrigger("Hit");
    }

    public void CheckDeath()
    {
        if (currentHp <= 0)
        {
            WaveManager.Instance.nbEnnemiAlive--;
            GameManager.Instance.score += stat.score;
            if (idCoverPointUsed != -1)
            {
                GameManager.Instance.coverPoint[idCoverPointUsed].isOccupied = false;
            }
            EnableRagdoll();
        }
    }

    private void EnableRagdoll()
    {
        transform.GetChild(0).GetComponent<Animator>().enabled = false;
        agent.enabled = false;
        this.enabled = false;
    }

    //Obligatoire de le laisser ici pour le instantiate (monoBehavior)
    public void Attack()
    {
        Instantiate(arrowPrefabs, arrowLunchTransform.position, arrowLunchTransform.rotation);
    }

    public void LookAtPlayer()
    {
        Vector3 direction = playerTransform.position - transform.position;
        direction.y = 0; // Éviter la rotation verticale

        // Calculer la rotation cible
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Appliquer une rotation douce vers la cible
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    
    // let the game dev change the range of enemy
    [SerializeField] float chaseRange = 5f;
    // let the game dev change the turning speed/time of the enemy when he faces his target
    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent navMeshAgent;
    float distenceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    EnemyHealth health;
    // insted of having a Serialized Field to diceid who is the target we tell the enemys inside the code
    Transform target;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        // find the object with the code PlayerHealth and "Follow" it
        target = FindObjectOfType<PlayerHealth>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (health.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
        /// the distence of the enemy from us is the target positon relative to him
        distenceToTarget = Vector3.Distance(target.position, transform.position);

        /// if the enemy is provoked than engage us 
        if (isProvoked)
        {
            EngageTarget();
        }
        /// if the enemy sees us than he is provoked
        else if (distenceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();
        /// when the enemy is engaged and if he's not close to us he will come for us
        if (distenceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        /// if the enemy is close to us he will attack
        if (distenceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true); 
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotatoin = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        // transform.rotation = where the target is, we need to rotate at acertain speed
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotatoin, Time.deltaTime * turnSpeed);
    }
    
    void OnDrawGizmosSelected()
    {
        // Display the search radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}

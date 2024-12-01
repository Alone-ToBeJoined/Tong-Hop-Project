using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    [SerializeField] Animator animator;
    [SerializeField] private GameObject objectToDestroy;

    public NavMeshAgent agent;
    private Vector3 destination;
    public WeaponType weaponType {  get; private set; } 
    public bool IsDestination => Vector3.Distance(new Vector3(destination.x, transform.position.y, destination.z), transform.position) < 0.1f;

    protected virtual void Start()
    {
        OnInit();   
    }

    private bool isDead = false;
    private IState<Bot> currentState;

    void Update()
    {
        if (currentState != null)
        {
            currentState.OnExcute(this);    
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            ChangeAnim(Constant.DeadAnimName);
            Death();
        }
    }

    public Vector3 TargetEnemy
    {
        get { return targetEnemy; }
    }

    private void OnInit()
    {
        ChangeState(new FindState());
        weaponType = (WeaponType)Random.Range(0, 3);
        
    }
    public void ChangeState(IState<Bot> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);  
        }

        currentState = state;   

        if (currentState != null)
        {
            currentState.OnEnter(this);             
        }
    }

    public bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range; 
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = transform.position;    
        return false;
    }

    public void SetDestination(Vector3 position)
    {
        agent.enabled = true;
        destination = position; 
        destination.y = 0;  
        agent.SetDestination(position); 
    }

    public void FindToEnemy()
    {
        base.FindTarget(transform.position, radius);
    }

    public void OnAttack()
    {
        agent.enabled = false;
        base.Attack();  
    }

    public void MoveStop()
    {
        agent.enabled = false;  
    }
}

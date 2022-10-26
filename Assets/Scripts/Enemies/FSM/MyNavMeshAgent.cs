using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyNavMeshAgent : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform target;
    private Vector3 originalPos;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform; 
        originalPos =  new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    public void EnemyPosReset()
    {

        gameObject.transform.position = originalPos;

    }

    public void GoToDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    public bool IsAtDestination()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if ((!agent.hasPath) || (agent.velocity.sqrMagnitude == 0))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void GoToTarget()
    {
        agent.SetDestination(target.position);
    }

    public void StopAgent()
    {
        agent.isStopped = true;
        agent.ResetPath();
    }
}

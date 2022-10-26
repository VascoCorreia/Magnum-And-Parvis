using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Wander")]
public class WanderAction : Action
{
    private float timer = 0;

    [SerializeField]
    private float wanderRadius;
    [SerializeField]
    private float wanderTimer = 2;

    public override void Act(FiniteStateMachine fsm)
    {
        timer += Time.deltaTime;
        if(timer >= wanderTimer)
        {

            fsm.GetAgent().GoToDestination(RandomNavSphere(fsm.GetAgent().transform.position, wanderRadius, -1));
            timer = 0;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;

        randomDirection += origin;


        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }
}

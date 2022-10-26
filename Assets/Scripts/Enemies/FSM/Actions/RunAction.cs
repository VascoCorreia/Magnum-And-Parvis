using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Run")]
public class RunAction : Action
{ 

    [SerializeField]
    private float distanceToPlayer;
    public override void Act(FiniteStateMachine fsm)
    {
        float distance = Vector3.Distance(fsm.GetAgent().transform.position, fsm.GetAgent().target.position);

        if(distance < distanceToPlayer)
        {
            Vector3 direction = fsm.GetAgent().transform.position - fsm.GetAgent().target.position;
            Vector3 newPos = fsm.GetAgent().transform.position + direction;

            fsm.GetAgent().GoToDestination(newPos);
        }
    }
}

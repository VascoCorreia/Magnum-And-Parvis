using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Inside Radius")]
public class InsideRadiusCondition : Condition
{
    [SerializeField]
    private float detectionRadius;

    [SerializeField]
    private bool negation;
    public override bool Test(FiniteStateMachine fsm)
    {
        if (Vector3.Distance(fsm.GetAgent().transform.position, fsm.GetAgent().target.position) < detectionRadius)
        {
            return !negation;
        }
        else
            return negation;
    }
}

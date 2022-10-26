using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Melee Attack")]
public class MeleeAttackAction : Action
{
    public EnemyData enemyData;

    [SerializeField]
    private float radius;

    public override void Act(FiniteStateMachine fsm)
    {
        fsm.GetAgent().gameObject.GetComponent<Animator>().enabled = true;
        float distance = Vector3.Distance(fsm.GetAgent().transform.position, fsm.GetAgent().target.position);

        if(distance < radius)
        {
            fsm.GetAgent().target.GetComponent<PlayerScript>().TakeDamage(enemyData.damage);
        }
            
    }



}

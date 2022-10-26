using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyBase
{
    [SerializeField]
    private FiniteStateMachine fsm;
    [SerializeField]
    private State attackState;
    void Update()
    {
        if (fsm.currentState == attackState)
            GetComponent<Animator>().enabled = true;
        else
            GetComponent<Animator>().enabled = false;
    }
}

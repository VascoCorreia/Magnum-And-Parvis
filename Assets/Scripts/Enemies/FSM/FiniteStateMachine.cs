using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour
{
    public State initialState;
    public State currentState;
    private MyNavMeshAgent navMeshAgent;
    
    // Start is called before the first frame update
    void Start()
    {
        currentState = initialState;
        navMeshAgent = GetComponent<MyNavMeshAgent>();
    }

    public MyNavMeshAgent GetAgent()
    {
        return navMeshAgent;
    }

    // Update is called once per frame
    void Update()
    {
        Transition triggeredTransition = null;
        foreach(Transition t in currentState.GetTransitions())
        {
            if (t.IsTriggered(this))
            {
                triggeredTransition = t;
                break;
            }
        }
        List<Action> actions = new List<Action>();
        if (triggeredTransition)
        {
            State targetState = triggeredTransition.GetTargetState();
            actions.Add(currentState.GetExitAction());
            actions.Add(triggeredTransition.GetAction());
            actions.Add(targetState.GetEntryAction());
            currentState = targetState;
        }
        else
        {
            foreach(Action a in currentState.GetActions())
            {
                actions.Add(a);
            }
        }
        DoActions(actions);
    }

    void DoActions(List<Action> actions)
    {
        foreach(Action a in actions)
        {
            if (a != null)
            {
                a.Act(this);
            }
        }
    }
}

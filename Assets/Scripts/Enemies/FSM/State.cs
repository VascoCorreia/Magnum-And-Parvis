﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/State")]
public class State : ScriptableObject
{
    [SerializeField]
    private Action entryAction;

    [SerializeField]
    private Action[] stateActions;

    [SerializeField]
    private Action exitAction;

    [SerializeField]
    private Transition[] transitions;

    public Action GetEntryAction()
    {
        return entryAction;
    }

    public Action GetExitAction()
    {
        return exitAction;
    }

    public Action[] GetActions()
    {
        return stateActions;
    }

    public Transition[] GetTransitions()
    {
        return transitions;
    }
}

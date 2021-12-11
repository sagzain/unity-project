using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class StateMachine : MonoBehaviour  
{
    // Máquina de Estados 
    protected IState _currentState;
    protected Dictionary<Enum, IState> _states;

    protected virtual void Awake()
    {
        _states = new Dictionary<Enum, IState>();
    }

    protected virtual void Start()
    {
        if(_currentState != null)
        {
            _currentState.EnterState(this);
        }
    }

    protected virtual void Update()
    {
        if(_currentState != null)
        {
            _currentState.Update(this);
        }
    }

    public void TransitionTo(Enum state)
    {
        _currentState = _states[state];
        _currentState.EnterState(this);
    }
}

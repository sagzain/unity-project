using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour  
{
    protected IState _currentState;
    protected Dictionary<Enum, IState> _states;

    public void AwakeMachine()
    {
        _states = new Dictionary<Enum, IState>();
    }

    public void StartMachine()
    {
        if(_currentState != null)
        {
            _currentState.EnterState(this);
        }
    }

    public void UpdateMachine()
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

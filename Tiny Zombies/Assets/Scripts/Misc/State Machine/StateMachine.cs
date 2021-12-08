using System;
using System.Collections.Generic;
using UnityEngine;


public class StateMachine : MonoBehaviour
{
    private IState _currentState;
    protected Dictionary<Enum, IState> _states;

    void Awake()
    {
        _states = new Dictionary<Enum, IState>();
    }

    void Start()
    {
        if(_currentState != null)
        {
            _currentState.EnterState(this);
        }
    }

    void Update()
    {
        if(_currentState != null)
        {
            _currentState.Update(this);
        }
    }

    public void TransitionTo(Enum state)
    {
        _currentState = _states[state];
    }
}

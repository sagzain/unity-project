using System;

public interface IState
{
    public void EnterState(StateMachine stateMachine);
    public void Update(StateMachine stateMachine);
    // public void Transition(StateMachine stateMachine);
}

using System.Collections;
using UnityEngine;

public class EnemyIdle : IState
{
    private Enemy _enemyFSM;

    public void EnterState(StateMachine stateMachine)
    {
        _enemyFSM = (Enemy)stateMachine;
        _enemyFSM.Animator.SetFloat("Velocity", 0);
        _enemyFSM.NavMeshAgent.ResetPath();
    }

    public void Update(StateMachine stateMachine)
    {
        if(_enemyFSM.DistanceToPlayer() <= _enemyFSM.ChasingRange)
        {
            stateMachine.TransitionTo(EnumEnemyState.Chasing);
        }
    }
}

using UnityEngine;

public class EnemyChasing : IState
{
    private Enemy _enemyFSM;

    public void EnterState(StateMachine stateMachine)
    {
        _enemyFSM = (Enemy)stateMachine;
        _enemyFSM.NavMeshAgent.speed = _enemyFSM.MovementSpeed;
        _enemyFSM.Animator.SetFloat("Velocity", 1);
    }

    public void Update(StateMachine stateMachine)
    {
        var distanceToPlayer = _enemyFSM.DistanceToPlayer();
        if (distanceToPlayer <= _enemyFSM.AttackRange)
        {
            _enemyFSM.TransitionTo(EnumEnemyState.Attacking);
        }
        else if(distanceToPlayer > _enemyFSM.ChasingRange)
        {
            _enemyFSM.TransitionTo(EnumEnemyState.Idle);
        }
        else
        {
            var playerPosition = Player.Instance.transform.position;
            _enemyFSM.NavMeshAgent.SetDestination(playerPosition);
            _enemyFSM.transform.LookAt(playerPosition);
        }
    }


}

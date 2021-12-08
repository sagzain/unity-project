using UnityEngine;
using UnityEngine.AI;


public class EnemyMovement : IState
{
    private NavMeshAgent _navMesh;
    private Animator _animator;

    public void EnterState(StateMachine stateMachine)
    {
        // _navMesh = stateMachine.GetNavMeshAgent();
        // _animator = stateMachine.GetAnimator();
    }

    public void Update(StateMachine stateMachine)
    {
        if(Player.Instance.IsAlive)
        {
            var playerPosition = Player.Instance.transform.position;

            _navMesh.SetDestination(playerPosition);
            _animator.SetFloat("Velocity", 1);
            stateMachine.transform.LookAt(playerPosition);
        }
    }
}

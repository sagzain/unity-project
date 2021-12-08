using UnityEngine;
using UnityEngine.AI;


public class EnemyChasing : IState
{
    private Animator _animator;
    private AudioSource _audioSource;
    private NavMeshAgent _navMeshAgent;

    public void EnterState(StateMachine stateMachine)
    {
        _animator = stateMachine.GetComponent<Animator>();
        _audioSource = stateMachine.GetComponent<AudioSource>();
        _navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();

        _animator.SetFloat("Velocity", 1);
    }

    public void Update(StateMachine stateMachine)
    {
        if(Player.Instance.IsAlive)
        {
            var playerPosition = Player.Instance.transform.position;
            _navMeshAgent.SetDestination(playerPosition);
            stateMachine.transform.LookAt(playerPosition);
        }
    }
}

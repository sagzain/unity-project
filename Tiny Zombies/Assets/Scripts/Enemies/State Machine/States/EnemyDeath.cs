using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDeath : IState
{
    private Animator _animator;
    private AudioSource  _audioSource;
    private NavMeshAgent _navMeshAgent;

    public void EnterState(StateMachine stateMachine)
    {
        _animator = stateMachine.GetComponent<Animator>();
        _audioSource = stateMachine.GetComponent<AudioSource>();
        _navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();

        _animator.SetFloat("Velocity", 0);
        _animator.SetBool("IsDead", true);

        _navMeshAgent.ResetPath();
    }

    public void Update(StateMachine stateMachine)
    {
        // Código 
    }
}

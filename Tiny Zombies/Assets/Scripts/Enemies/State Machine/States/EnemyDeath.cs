using UnityEngine;


public class EnemyDeath : IState
{
    private Enemy _enemyFSM;
    public void EnterState(StateMachine stateMachine)
    {
        _enemyFSM = (Enemy)stateMachine;
        _enemyFSM.Animator.SetFloat("Velocity", 0);
        _enemyFSM.Animator.SetTrigger("Death");
        _enemyFSM.NavMeshAgent.ResetPath();

        _enemyFSM.GetComponent<Collider>().enabled = false;
    }

    public void Update(StateMachine stateMachine)
    {
        // No tiene que hacer nada más 
    }
}

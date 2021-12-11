using UnityEngine;

public class EnemyAttack : IState
{
    private Enemy _enemyFSM;
    public void EnterState(StateMachine stateMachine)
    {
        _enemyFSM = (Enemy)stateMachine;
        _enemyFSM.Animator.SetTrigger("Attack");
        _enemyFSM.transform.LookAt(Player.Instance.transform);
    }

    public void Update(StateMachine stateMachine)
    {
        // No hace falta hacer nada más
    }
}

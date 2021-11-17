using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    [SerializeField] private GameObject _blood;

    private Health _health;
    private Animator _animator;

    public bool IsAlive => _health.IsAlive;

    void Awake()
    {
        _health = GetComponent<Health>();
        _animator = GetComponent<Animator>();
    }

    public void Death()
    {
        _animator.SetBool("IsDead", true);
        Instantiate(_blood, transform.position, _blood.transform.rotation);
    }
}

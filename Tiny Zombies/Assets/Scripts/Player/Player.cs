using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>, IDamageable
{
    [Header("Visuals")]
    [SerializeField] private GameObject _blood;
    
    [Header("Events")]
    [SerializeField] private GameEvent _damagedEvent;
    [SerializeField] private GameEvent _deathEvent;

    private Health _health;
    private Animator _animator;
    private AudioSource _audioSource;
 
    public bool IsAlive => _health.IsAlive;

    void Awake()
    {
        _health = GetComponent<Health>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void TakeDamage(int damage)
    {
        _health.DecreaseHealth(damage);
        
        _damagedEvent.Raise();

        if(!_health.IsAlive)
        {
            Death();
        }
    }

    public void Death()
    {
        _audioSource.Play();
        _animator.SetBool("IsDead", true);

        Vector3 position = transform.position;
        Vector3 floor = new Vector3(position.x, 0.15f, position.z);
        Instantiate(_blood, floor, _blood.transform.rotation);

        _deathEvent.Raise();
    }
}

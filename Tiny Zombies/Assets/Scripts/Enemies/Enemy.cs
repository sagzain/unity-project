using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("Stats")]
    [SerializeField] protected Health health;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _movementSpeed;

    [Header("Visuals")]
    [SerializeField] private GameObject _blood;

    [Header("Audio")]
    [SerializeField] private AudioClip _idleSound;
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private AudioClip _attackSound;

    private Animator _animator;
    private AudioSource _audioSource;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();    
    }

    public void TakeDamage(int amount)
    {
        if(health.IsAlive)
        {
            health.DecreaseHealth(amount);
        }
    }

    public void Death()
    {
        _audioSource.PlayOneShot(_deathSound);
        _animator.SetBool("IsDead", true);
    }
}

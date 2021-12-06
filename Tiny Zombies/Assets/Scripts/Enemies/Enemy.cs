using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ISpawnable, IDamageable
{
    [Header("Stats")]
    // [SerializeField] protected Health _health;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _movementSpeed;

    [Header("Rewards")]
    [SerializeField] private int score;

    [Header("Visuals")]
    [SerializeField] private GameObject _blood;

    [Header("Audio")]
    [SerializeField] private AudioClip _idleSound;
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private AudioClip _attackSound;


    [SerializeField] private float _timeToDestroy = .5f;
    [SerializeField] private float _maxDistance = 10f, _minDistance = 2f;

    private Transform _playerTransform;
    private Animator _animator;
    private AudioSource _audioSource;

    private bool _isAttacking = false;
    private float _distanceToPlayer;

    void Awake()
    {
        _playerTransform = Player.Instance.transform;
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        _distanceToPlayer = 99;
        if (Player.Instance.IsAlive)
        {
            _distanceToPlayer = Vector3.Distance(transform.position, _playerTransform.position);
        }

        if (_animator.GetBool("IsDead") == false)
        {
            if (_distanceToPlayer > _minDistance && _distanceToPlayer <= _maxDistance)
            {
                _animator.SetFloat("Velocity", 1);
                transform.position += transform.forward * _movementSpeed * Time.deltaTime;
                transform.LookAt(_playerTransform);
            }
            else
            {
                _animator.SetFloat("Velocity", 0);
            }


            _isAttacking = _distanceToPlayer <= _minDistance ? true : false;
            _animator.SetBool("IsAttacking", _isAttacking);
        }
    }


    public void TakeDamage(int amount)
    {
        _health -= amount;

        if(_health <= 0)
        {
            Death();
        }
        // _health.DecreaseHealth(amount);

        // if(_health.IsAlive)
        // {
        //     Death();
        // }
    }

    public void Damage()
    {
        _audioSource.PlayOneShot(_attackSound);

        if (Player.Instance.IsAlive)
        {
            Player.Instance.GetComponent<Health>().DecreaseHealth(_damage);
        }
    }

    public void Death()
    {
        if (!_animator.GetBool("IsDead"))
        {
            // Play death animation and death audio
            _animator.SetBool("IsDead", true);
            // _audioSource.Stop();
            _audioSource.PlayDelayed(.15f);
            _audioSource.PlayOneShot(_deathSound);

            // Blood Instantiation above the floor to avoid visual glitches with the ground
            Vector3 position = transform.position;
            Vector3 floor = new Vector3(position.x, 0.15f, position.z);
            Instantiate(_blood, floor, _blood.transform.rotation);

            // Despawn the dead zombie GameObject
            // StartCoroutine(Despawn());
        }
    }


    public void OnSpawn()
    {
        //Codigo DOTween para hacer animación de entrada
        // Settear la mascara para hacer colisiónn con el raycast
    }

    public void OnDespawn()
    {
        //Código DOTween para hacer animación de salida
        // Settear la mascara para dejar de colisionar con el raycast
    }
}

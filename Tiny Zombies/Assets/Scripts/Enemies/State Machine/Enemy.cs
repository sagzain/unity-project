using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator), typeof(AudioSource))]
public class Enemy : StateMachine, ISpawnable, IDamageable
{
    [Header("Stats")]
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

    public GameObject Blood => _blood;
    public AudioClip IdleSound => _idleSound;
    public AudioClip DeathSound => _deathSound;
    public AudioClip AttackSound => _attackSound;
    
    // [SerializeField] private float _timeToDestroy = .5f;
    // [SerializeField] private float _maxDistance = 10f, _minDistance = 2f;

    // private Transform _playerTransform;
    private Animator _animator;
    private AudioSource _audioSource;
    private NavMeshAgent _navMeshAgent;

    // private bool _isAttacking = false;
    // private float _distanceToPlayer;

    void Awake()
    {
        // Inicializamos la máquina de estados
        base.AwakeMachine();

        // Obtenemos los componentes necesarios para el enemigo
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        // Creamos los estados que va a contener la máquina de estados
        IState idle = new EnemyIdle();
        IState chasing = new EnemyChasing();
        IState attacking = new EnemyAttack();
        IState dead = new EnemyDeath();

        _states.Add(EnumEnemyState.Idle, idle);
        _states.Add(EnumEnemyState.Chasing, chasing);
        _states.Add(EnumEnemyState.Attacking, attacking);
        _states.Add(EnumEnemyState.Dead, dead);

        // Comenzamos la máquina de estados en el idle
        TransitionTo(EnumEnemyState.Idle);
        base.StartMachine();
    }

    void FixedUpdate()
    {
        base.UpdateMachine();
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;

        if(_health <= 0)
        {
            TransitionTo(EnumEnemyState.Dead);
        }
    }

    // public void Damage()
    // {
    //     _audioSource.PlayOneShot(_attackSound);

    //     if (Player.Instance.IsAlive)
    //     {
    //         Player.Instance.GetComponent<Health>().DecreaseHealth(_damage);
    //     }
    // }

    public void Death()
    {
        // if (!_animator.GetBool("IsDead"))
        // {
        //     // Play death animation and death audio
        //     _animator.SetBool("IsDead", true);
        //     // _audioSource.Stop();
        //     _audioSource.PlayDelayed(.15f);
        //     _audioSource.PlayOneShot(_deathSound);

        //     // Blood Instantiation above the floor to avoid visual glitches with the ground
        //     Vector3 position = transform.position;
        //     Vector3 floor = new Vector3(position.x, 0.15f, position.z);
        //     Instantiate(_blood, floor, _blood.transform.rotation);

        //     // Despawn the dead zombie GameObject
        //     // StartCoroutine(Despawn());
        // }
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

// Se utilizaba para comprobar la distancia hasta el jugador y asi hacer el ataque
// void FixedUpdate()
    // {
        // _distanceToPlayer = 99;
        // if (Player.Instance.IsAlive)
        // {
        //     _distanceToPlayer = Vector3.Distance(transform.position, _playerTransform.position);
        // }

        // if (_animator.GetBool("IsDead") == false)
        // {
        //     if (_distanceToPlayer > _minDistance && _distanceToPlayer <= _maxDistance)
        //     {
        //         _animator.SetFloat("Velocity", 1);
        //         transform.position += transform.forward * _movementSpeed * Time.deltaTime;
        //         transform.LookAt(_playerTransform);
        //     }
        //     else
        //     {
        //         _animator.SetFloat("Velocity", 0);
        //     }


        //     _isAttacking = _distanceToPlayer <= _minDistance ? true : false;
        //     _animator.SetBool("IsAttacking", _isAttacking);
        // }
    // }

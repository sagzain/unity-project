using UnityEngine;
using UnityEngine.AI;
using System;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator), typeof(AudioSource))]
public class Enemy : StateMachine, ISpawnable, IDamageable
{
    [Header("Enemy Information")]
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _chaseRange;
    [SerializeField] private int _score;

    public float MovementSpeed => _movementSpeed;
    public float AttackRange => _attackRange;
    public float ChasingRange => _chaseRange;

    [Header("Visuals")]
    [SerializeField] private GameObject _blood;

    [Header("Sounds")]
    [SerializeField] private AudioClip _idleSound;
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private AudioClip _attackSound;
    
    // Componentes necesarios para el enemigo
    protected Animator _animator;
    protected AudioSource _audioSource;
    protected NavMeshAgent _navMeshAgent;


    // Accesibilidad a componentes para los estados
    public Animator Animator => _animator;
    public AudioSource AudioSource => _audioSource;
    public NavMeshAgent NavMeshAgent => _navMeshAgent;

    protected override void Awake()
    {
        // Inicializamos la máquina de estados
        base.Awake();

        // Obtenemos los componentes necesarios para la máquina de estados
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    protected override void Start()
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
        _currentState = idle;

        base.Start();
    }

    protected override void Update()
    {
        if(Player.Instance.IsAlive)
        {
            base.Update();
        }
    }

    public float DistanceToPlayer()
    {
        var playerPosition = Player.Instance.transform.position;
        return Vector3.Distance(transform.position, playerPosition);
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;

        if (_health <= 0)
        {
            Death();
        }
    }

    public IEnumerator Damage()
    {
        _audioSource.PlayOneShot(_attackSound);

        RaycastHit hit;
        
        if(Physics.Raycast(transform.position, transform.forward, out hit, 1 << 6))
        {
            Debug.DrawRay(transform.position, Vector3.forward, Color.yellow);
            hit.collider.GetComponent<IDamageable>().TakeDamage(_damage);        
        }

        yield return new WaitForSeconds(_attackDelay);

        if(_currentState.GetType() != typeof(EnemyDeath))
        {
            TransitionTo(EnumEnemyState.Idle);
        }
    }

    public void Death()
    {
        _audioSource.Stop();
        _audioSource.PlayDelayed(.15f);
        _audioSource.PlayOneShot(_deathSound);

        TransitionTo(EnumEnemyState.Dead);
         
        // Blood Instantiation above the floor to avoid visual glitches with the ground
        Vector3 position = transform.position;
        Vector3 floor = new Vector3(position.x, 0.15f, position.z);
        Instantiate(_blood, floor, _blood.transform.rotation);

        // Despawn the dead zombie GameObject
        OnDespawn();
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

        StartCoroutine(Despawn());
    }

    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(2.25f);

        PoolManager.Instance.Despawn(this.gameObject);
    }

    public void SetEnemyConfiguration(ScriptableEnemy enemySO)
    {
        _maxHealth = enemySO.Health;
        _health = _maxHealth;
        _movementSpeed = enemySO.MovementSpeed;
        _damage = enemySO.Damage;
        _attackRange = enemySO.AttackRange;
        _attackDelay = enemySO.AttackDelay;
        _chaseRange= enemySO.ChaseRange;
        _blood = enemySO.Blood;
        _idleSound = enemySO.IdleSound;
        _deathSound = enemySO.DeathSound;
        _attackSound = enemySO.AttackSound;
    }

    void OnEnable()
    {
        _health = _maxHealth;
        GetComponent<Collider>().enabled = true;
        
        try
        {
            TransitionTo(EnumEnemyState.Idle);
        }
        catch(Exception){}
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Enemy", fileName = "Enemy Configuration")]
public class ScriptableEnemy : ScriptableObject
{
    [Header("Stats")]
    [Tooltip("Cantidad de daño que puede recibir el enemigo antes de morir")]
    [SerializeField] private int _health;
    [Tooltip("Daño que causa el enemigo al jugador con cada ataque")]
    [SerializeField] private int _damage;
    [Tooltip("Velocidad a la cual persigue un enemigo")]
    [SerializeField] private float _movementSpeed;
    [Tooltip("Distancia a la cual un enemigo puede atacar")]
    [SerializeField] private float _attackRange;
    [Tooltip("Tiempo de espera del enemigo para poder realizar otro ataque")]
    [SerializeField] private float _attackDelay;
    [Tooltip("Distancia a la cual un enemigo empieza a perseguir")]
    [SerializeField] private float _chaseRange;


    [Header("Rewards")]
    [Tooltip("Puntuacion que se le da al jugador por matar a este enemigo")]
    [SerializeField] private int _score;

    [Header("Visuals")]
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _blood;

    [Header("Audio")]
    [SerializeField] private AudioClip _idleSound;
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private AudioClip _attackSound;

    public int Health => _health;
    public int Damage => _damage;
    public float MovementSpeed => _movementSpeed;
    public float AttackRange => _attackRange;
    public float AttackDelay => _attackDelay;
    public float ChaseRange => _chaseRange;
    public int Score => _score;
    public GameObject EnemyPrefab => _enemyPrefab;
    public GameObject Blood => _blood;
    public AudioClip IdleSound => _idleSound;
    public AudioClip DeathSound => _deathSound;
    public AudioClip AttackSound => _attackSound; 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{   
    [Header("Stats")]
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _moveSpeed = 3f;
    
    [Header("Other parameters")]
    [SerializeField] private GameObject _blood;
    [SerializeField] private float _timeToDestroy = .5f;
    [SerializeField] private float _maxDistance = 10f, _minDistance = 2f;

    private Transform _playerTransform;
    private Animator _animator;
    private bool _isAttacking = false;
    private float  _distanceToPlayer;

    void Awake()
    {
        _playerTransform = Player.Instance.transform;
        _animator = GetComponent<Animator>();
    } 

    void FixedUpdate()
    {
        _distanceToPlayer = 99;
        if(Player.Instance.IsAlive)
        {
            _distanceToPlayer = Vector3.Distance(transform.position, _playerTransform.position);
        }
        
        if(_animator.GetBool("IsDead") == false)
        {
            if(_distanceToPlayer > _minDistance && _distanceToPlayer <= _maxDistance )
            {
                _animator.SetFloat("Velocity", 1);
                transform.position += transform.forward * _moveSpeed * Time.deltaTime;
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

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Player") Debug.Log("Colision con jugador");

        if(!_animator.GetBool("IsDead") && other.gameObject.tag == "Bullet")
        {
            Vector3 position = transform.position;
            Vector3 floor = new Vector3(position.x, 0.1f, position.z);
            _animator.SetBool("IsDead", true);
            Instantiate(_blood, floor, _blood.transform.rotation);
            StartCoroutine(Despawn());  
        }  
    }

    public void Damage()
    {
        // if(_distanceToPlayer <= _minDistance)
        // {
            Player.Instance.GetComponent<Health>().TakeDamage(_damage);
        // }
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(_timeToDestroy);
        Destroy(gameObject);
    }   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _timeToDestroy = .5f;

    private Transform _playerTransform;

    void Awake()
    {
        _playerTransform = Player.Instance.transform;
    } 

    void Update()
    {
        transform.position += transform.forward * _moveSpeed * Time.deltaTime;
        transform.LookAt(_playerTransform);
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Bullet")
        {
            StartCoroutine(DestroyInSeconds());  
        }  
    }

    IEnumerator DestroyInSeconds()
    {
        yield return new WaitForSeconds(_timeToDestroy);
        Destroy(this.gameObject);
    }   
}

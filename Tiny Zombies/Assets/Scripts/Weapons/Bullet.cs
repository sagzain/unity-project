using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 20.0f;
    [SerializeField] private float _timeToDestroy = 2.5f; 

    void Start()
    {
        StartCoroutine(DestroyOnTime());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * _bulletSpeed * Time.deltaTime;
    }

    IEnumerator DestroyOnTime()
    {
        yield return new WaitForSeconds(_timeToDestroy);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other) 
    {
        //Coger el Health del enemigo y comprobar que está vivo para destruir la bala. En caso contrario la bala debe continuar su camino
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}

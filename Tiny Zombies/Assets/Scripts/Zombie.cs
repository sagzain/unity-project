using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy = 2.5f;

    private void OnCollisionEnter(Collision other) 
    {
        StartCoroutine(DestroyInSeconds());    
    }

    IEnumerator DestroyInSeconds()
    {
        yield return new WaitForSeconds(_timeToDestroy);
        Destroy(this.gameObject);
    }   
}

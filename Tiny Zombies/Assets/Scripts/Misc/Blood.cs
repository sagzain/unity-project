using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    [SerializeField] private float _timeToDespawn;
    
    void OnEnable()
    {
        StartCoroutine(DespawnBlood());
    }

    IEnumerator DespawnBlood()
    {
        yield return new WaitForSeconds(_timeToDespawn);
        Destroy(gameObject);
    }
}

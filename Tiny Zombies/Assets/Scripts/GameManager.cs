using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Scene References")]
    [SerializeField] private Transform _playground;

    [Header("Prefabs")]
    [SerializeField] private GameObject _enemyPrefab;


    void Start()
    {
        PoolManager.Instance.Load(_enemyPrefab, 20);
        StartCoroutine(Spawn(_enemyPrefab));
    }

    IEnumerator Spawn(GameObject prefab)
    {
        while(true)
        {
            yield return new WaitForSeconds(2f);

            if(Player.Instance.IsAlive)
            {
            var randomPosition = Random.insideUnitCircle;
            Vector3 spawnPoint = new Vector3(randomPosition.x, 0, randomPosition.y).normalized * Random.Range(0, 14);

            var enemy = PoolManager.Instance.Spawn(prefab);
            
            enemy.transform.position = spawnPoint;
            }
        }
    }
}

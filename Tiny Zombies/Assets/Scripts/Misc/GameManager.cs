using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Scene References")]
    [SerializeField] private Transform _playground;

    [Header("Enemy Scriptable Objects")]
    [SerializeField] private ScriptableEnemy _zombieSO;
    // [SerializeField] private ScriptableEnemy _headSO;

    [Header("Options")]
    [SerializeField] private int _totalZombies;
    // [SerializeField] private int _totalHeads;
    [SerializeField] private float _spawnDelayZombies;
    // [SerializeField] private float _spawnDelayHeads;

    void Start()
    {
        /* 
            La finalidad de esta parte es poder refactorizarla a un sistema más modular
            teniendo un Scriptable Object del Nivel que indique que enemigos van a cargarse 
            y cuantos cargar (así como el delay o probabilidad de spawn de cada uno de ellos)
        */
        GameObject zombie = _zombieSO.EnemyPrefab;
        zombie.GetComponent<Enemy>().SetEnemyConfiguration(_zombieSO);

        // GameObject head = _headSO.EnemyPrefab;
        // head.GetComponent<Enemy>().SetEnemyConfiguration(_headSO);

        PoolManager.Instance.Load(zombie, _totalZombies);
        StartCoroutine(Spawn(zombie, _spawnDelayZombies));

        // PoolManager.Instance.Load(head, _totalHeads);
        // StartCoroutine(Spawn(head, _spawnDelayHeads));
    }

    IEnumerator Spawn(GameObject prefab, float spawningTime)
    {
        while(true)
        {
            yield return new WaitForSeconds(spawningTime);

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

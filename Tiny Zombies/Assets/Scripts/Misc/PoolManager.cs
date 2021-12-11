using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    private Dictionary<string, List<GameObject>> _pool;
    private Transform _poolParent;

    void Awake()
    {
        this._pool = new Dictionary<string, List<GameObject>>();
        this._poolParent = new GameObject("Pool Parent").transform;
    }

    public void Load(GameObject prefab, int quantity = 1)
    {
        var prefabName = prefab.name;

        if(!_pool.ContainsKey(prefabName))
        {
            _pool[prefabName] = new List<GameObject>();
        }

        for(int i = 0; i < quantity; i++)
        {
            var prefabInstance = Instantiate(prefab);
            prefabInstance.name = prefabName;
            prefabInstance.transform.SetParent(_poolParent);
            prefabInstance.SetActive(false);
            _pool[prefabName].Add(prefabInstance);
        }
    }

    public GameObject Spawn(GameObject prefab)
    {
        if(!_pool.ContainsKey(prefab.name) || _pool[prefab.name].Count == 0)
        {
            Load(prefab, 1);
        }

        var prefabList = _pool[prefab.name];
        var gameObject = prefabList[0];
        
        prefabList.RemoveAt(0);
        gameObject.SetActive(true);
        gameObject.transform.SetParent(null, false);

        foreach(var spawnable in gameObject.GetComponents<ISpawnable>())
        {
            if(spawnable != null)
            {
                spawnable.OnSpawn();
            }
        }

        return gameObject;
    }

    public void Despawn(GameObject prefab)
    {
        var prefabName = prefab.name;
    
        if(!_pool.ContainsKey(gameObject.name))
        {
            _pool[prefabName] = new List<GameObject>();
        }

        foreach(var spawnable in prefab.GetComponents<ISpawnable>())
        {
            if(spawnable != null)
            {
                spawnable.OnDespawn();
            }
        }

        prefab.SetActive(false);
        prefab.transform.SetParent(_poolParent, false);
        _pool[prefabName].Add(prefab);
    }

}

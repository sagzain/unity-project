using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    Dictionary<string, List<GameObject>> pool;
    Transform poolParent;

    void Awake()
    {
        this.pool = new Dictionary<string, List<GameObject>>();
        this.poolParent = new GameObject("Pool Parent").transform;
    }

    public void Load(GameObject prefab, int quantity = 1)
    {
        var prefabName = prefab.name;

        if(!pool.ContainsKey(prefabName))
        {
            pool[prefabName] = new List<GameObject>();
        }

        for(int i = 0; i < quantity; i++)
        {
            var prefabInstance = Instantiate(prefab);
            prefabInstance.name = prefabName;
            prefabInstance.transform.SetParent(poolParent);
            prefabInstance.SetActive(false);
            pool[prefabName].Add(prefabInstance);
        }
    }

    public GameObject Spawn(GameObject prefab)
    {
        if(!pool.ContainsKey(prefab.name) || pool[prefab.name].Count == 0)
        {
            Load(prefab, 1);
        }

        var prefabList = pool[prefab.name];
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
    
        if(!pool.ContainsKey(gameObject.name))
        {
            pool[prefabName] = new List<GameObject>();
        }

        foreach(var spawnable in prefab.GetComponents<ISpawnable>())
        {
            if(spawnable != null)
            {
                spawnable.OnDespawn();
            }
        }

        prefab.SetActive(false);
        prefab.transform.SetParent(poolParent, false);
        pool[prefabName].Add(prefab);
    }

}

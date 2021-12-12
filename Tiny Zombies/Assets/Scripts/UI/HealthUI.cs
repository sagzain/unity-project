using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject _heartPrefab;
    private List<GameObject> _hearts;

    void Start()
    {
        _hearts =  new List<GameObject>();
        AddHearts(3);
    }

    public void LooseHeart()
    {
        if(_hearts.Count > 0) 
        {
            var heart = _hearts[0];
            _hearts.RemoveAt(0);

            Destroy(heart);
        }
    }

    void AddHearts(int quantity)
    {
        for(int i = 0; i < quantity; i++)
        {
            var instance = Instantiate(_heartPrefab, transform.position, transform.rotation);
            instance.transform.SetParent(gameObject.transform);
            _hearts.Add(instance);
        }
    }
 }

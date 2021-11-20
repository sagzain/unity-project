using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _target;

    [SerializeField] private float _followSpeed = .125f; 
    [SerializeField] private Vector3 _offset;

    void Awake()
    {
        _offset = transform.position;
        _target = Player.Instance.transform;
    }

    void LateUpdate() 
    {
        transform.position = Vector3.Lerp(transform.position, _target.position + _offset, _followSpeed);
    }

}

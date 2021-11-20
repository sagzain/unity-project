using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _reloadTime = 2f;
    [SerializeField] private float _shootingDelay = 0.75f;
    [SerializeField] private int _totalBullets = 6;
    
    private Transform _outputPoint;
    private AudioSource _audioSource;
    private bool _shotAvailable = true;

    void Awake()
    {
        _outputPoint = transform.GetChild(0).gameObject.transform;
        _audioSource = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        if(_shotAvailable)
        {
            _totalBullets--;
            _shotAvailable = false;
            _audioSource.Play();            
            Instantiate(_bulletPrefab, _outputPoint.position, transform.rotation);
            
            var function = _totalBullets <= 0 ? StartCoroutine(Reload()) : StartCoroutine(ShootDelay());
        }
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(_shootingDelay);
        _shotAvailable = true;
    }

    IEnumerator Reload()
    {
        Debug.Log("Reloading");
        yield return new WaitForSeconds(_reloadTime);
        _shotAvailable = true;
        _totalBullets = 6;
    }
}

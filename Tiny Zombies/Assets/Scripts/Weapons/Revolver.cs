using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private AudioClip _reloadSound;
    [SerializeField] private AudioClip _delaySound;
    [SerializeField] private float _reloadTime = 4f;
    [SerializeField] private float _shootingDelay = 0.75f;
    [SerializeField] private int _totalBullets = 6;

    private Transform _outputPoint;
    private Animator _muzzleFlash;
    private AudioSource _audioSource;
    private bool _shotAvailable = true;

    void Awake()
    {
        _outputPoint = transform.GetChild(0).gameObject.transform;
        _muzzleFlash = _outputPoint.GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            var target = hit.point;
            Debug.DrawLine(transform.position, target, Color.yellow);
        }
    }

    public void Shoot()
    {
        if (_shotAvailable)
        {
            RaycastHit hit;
            
            if(Physics.Raycast(transform.position, transform.forward, out hit))
            {
                hit.collider.gameObject.GetComponent<Zombie>().Death(); // Generalizar mucho más este código haciendo uso de interfaces
                var end = new Vector3(0, 0, Vector3.Distance(transform.position, hit.point));
                _outputPoint.GetChild(1).gameObject.GetComponent<LineRenderer>().SetPosition(1, end);
            }
            else 
            {
                _outputPoint.GetChild(1).gameObject.GetComponent<LineRenderer>().SetPosition(1, new Vector3(0,0,20));
            }

            _totalBullets--;
            _shotAvailable = false;
            _audioSource.Play();
            _muzzleFlash.SetTrigger("Shoot");
            // Instantiate(_bulletPrefab, _outputPoint.position, transform.rotation);

            var function = _totalBullets <= 0 ? StartCoroutine(Reload()) : StartCoroutine(ShootDelay());
        }
    }

    IEnumerator ShootDelay()
    {
        _audioSource.PlayOneShot(_delaySound);
        yield return new WaitForSeconds(_shootingDelay);
        _shotAvailable = true;
    }

    IEnumerator Reload()
    {
        _audioSource.PlayOneShot(_reloadSound);
        yield return new WaitForSeconds(_reloadTime);
        _shotAvailable = true;
        _totalBullets = 6;
    }
}

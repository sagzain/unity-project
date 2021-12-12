using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField] private ScriptableWeapon _weapon;
    [SerializeField] private int _currentBullets;

    [Header("Events")]
    [SerializeField] private GameEvent _shootingEvent;
    [SerializeField] private GameEvent _reloadEvent;

    private Transform _outputPoint;
    private Animator _muzzleFlash;
    private AudioSource _audioSource;

    private bool _shotAvailable = true;
    
    public ScriptableWeapon WeaponInfo => _weapon;

    void Awake()
    {
        _outputPoint = transform.GetChild(0).gameObject.transform;
        _muzzleFlash = _outputPoint.GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

        _currentBullets = _weapon.TotalBullets;
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
                var target = hit.collider.gameObject.GetComponent<IDamageable>();
                
                if(target != null)
                {
                    target.TakeDamage(_weapon.Damage);
                }

                var end = new Vector3(0, 0, Vector3.Distance(transform.position, hit.point));
                _outputPoint.GetChild(1).gameObject.GetComponent<LineRenderer>().SetPosition(1, end);
            }
            else 
            {
                _outputPoint.GetChild(1).gameObject.GetComponent<LineRenderer>().SetPosition(1, new Vector3(0,0,20));
            }

            _currentBullets--;
            _shotAvailable = false;
            _audioSource.Play();
            _muzzleFlash.SetTrigger("Shoot");

            _shootingEvent.Raise();

            var function = _currentBullets <= 0 ? StartCoroutine(Reload()) : StartCoroutine(ShootDelay());
        }
    }

    IEnumerator ShootDelay()
    {
        _audioSource.PlayOneShot(_weapon.DelaySound);
        yield return new WaitForSeconds(_weapon.ShootingDelay);
        _shotAvailable = true;
    }

    IEnumerator Reload()
    {
        _reloadEvent.Raise();
        _audioSource.PlayOneShot(_weapon.ReloadSound);
        yield return new WaitForSeconds(_weapon.ReloadTime);
        _shotAvailable = true;
        _currentBullets = _weapon.TotalBullets;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] private GameObject _ammoPrefab;
    private List<GameObject> _bullets;
    private ScriptableWeapon _weapon;

    void Awake()
    {
        var weaponGO = GameObject.FindWithTag("Weapon");
        var weaponComp = weaponGO.GetComponent<Weapon>();
        _weapon = weaponComp.WeaponInfo;
    }

    void Start()
    {
        _bullets = new List<GameObject>();
        AddBullets(_weapon.TotalBullets);
    }
 
    public void ShootBullet()
    {
        StartCoroutine(ShootBulletCoroutine());
    }

    public IEnumerator ShootBulletCoroutine()
    {

        yield return new WaitForSeconds(.1f);
        
        if(_bullets.Count > 0) 
        {
            var bullet = _bullets[0];
            _bullets.RemoveAt(0);

            Destroy(bullet);
        }
    }

    public void ReloadBullets()
    {
        StartCoroutine(ReloadBulletsCoroutine());
    }

    public IEnumerator ReloadBulletsCoroutine()
    {
        for(int i = 0; i < _weapon.TotalBullets; i++)
        {
            yield return new WaitForSeconds(_weapon.ReloadTime/(_weapon.TotalBullets + 1));
            AddBullets(1);
        }
    }

    void AddBullets(int quantity)
    {
        for(int i = 0; i < quantity; i++)
        {
            var instance = Instantiate(_ammoPrefab, transform.position, transform.rotation);
            instance.transform.SetParent(gameObject.transform);
            _bullets.Add(instance); 
        }
    }
}

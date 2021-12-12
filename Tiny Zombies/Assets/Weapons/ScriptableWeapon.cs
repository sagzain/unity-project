using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Weapon", fileName = "New Weapon")]
public class ScriptableWeapon : ScriptableObject
{
    [Header("Stats")]
    [SerializeField] private int _damage;
    [SerializeField] private int _totalBullets;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _shootingDelay;

    [Header("Audio")]
    [SerializeField] private AudioClip _reloadSound;
    [SerializeField] private AudioClip _delaySound;

    public int Damage => _damage;
    public int TotalBullets => _totalBullets;
    public float ReloadTime => _reloadTime;
    public float ShootingDelay => _shootingDelay;
    public AudioClip ReloadSound => _reloadSound;
    public AudioClip DelaySound => _delaySound;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    [SerializeField] private GameObject _blood;
    [SerializeField] private List<AudioClip> _sounds = new List<AudioClip>();
    private Health _health;
    private Animator _animator;
    private AudioSource _audioSource;

    public bool IsAlive => _health.IsAlive;

    void Awake()
    {
        _health = GetComponent<Health>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void Death()
    {
        _audioSource.PlayOneShot(_sounds[0]);
        _animator.SetBool("IsDead", true);

        Vector3 position = transform.position;
        Vector3 floor = new Vector3(position.x, 0.1f, position.z);
        Instantiate(_blood, floor, _blood.transform.rotation);
    }
}

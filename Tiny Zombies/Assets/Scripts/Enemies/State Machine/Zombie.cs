using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    // [Header("Stats")]
    // [SerializeField] private int _damage = 1;
    // [SerializeField] private float _moveSpeed = 3f;

    // [Header("Other parameters")]
    // [SerializeField] private GameObject _blood;
    // [SerializeField] private List<AudioClip> _sounds = new List<AudioClip>();
    

    // // void Start()
    // // {
    // //     StartCoroutine(ZombieSound());

    // // }

    // // IEnumerator ZombieSound()
    // // {
    // //     while (!_animator.GetBool("IsAttacking") && !_animator.GetBool("IsDead"))
    // //     {
    // //         _audioSource.clip = _sounds[0];
    // //         int random = Random.Range(1, 5);
    // //         _audioSource.PlayDelayed(random);
    // //         yield return new WaitForSeconds(_audioSource.clip.length + random);
    // //     }

    // // }

    
    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.tag == "Player") Debug.Log("Colision con jugador");

    //     if (other.gameObject.tag == "Bullet")
    //     {
    //         Death();
    //     }
    // }

    // public void Death()
    // {
    //     if (!_animator.GetBool("IsDead"))
    //     {
    //         // Play death animation and death audio
    //         _animator.SetBool("IsDead", true);
    //         // _audioSource.Stop();
    //         _audioSource.PlayDelayed(.15f);
    //         // _audioSource.PlayOneShot(_sounds[2]);

    //         // Blood Instantiation above the floor to avoid visual glitches with the ground
    //         Vector3 position = transform.position;
    //         Vector3 floor = new Vector3(position.x, 0.1f, position.z);
    //         Instantiate(_blood, floor, _blood.transform.rotation);

    //         // Despawn the dead zombie GameObject
    //         StartCoroutine(Despawn());
    //     }
    // }

    // public void Damage()
    // {
    //     _audioSource.PlayOneShot();

    //     // if (Player.Instance.IsAlive)
    //     // {
    //     //     Player.Instance.GetComponent<Health>().TakeDamage(_damage);
    //     // }
    // }

    // IEnumerator Despawn()
    // {
    //     yield return new WaitForSeconds(_timeToDestroy);
    //     Destroy(gameObject);
    // }
}

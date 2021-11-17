using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;
    [SerializeField] private int _currentHealth;

    public bool IsAlive => _currentHealth > 0;

    void OnEnable()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int value)
    {
        _currentHealth -= value;

        if(!IsAlive)
        {
            Player.Instance.Death();
        }
    }
}

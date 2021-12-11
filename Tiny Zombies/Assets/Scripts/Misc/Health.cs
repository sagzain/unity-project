using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] 
    private int _maxHealth = 3;

    [SerializeField] 
    private int _currentHealth;

    public bool IsAlive => _currentHealth > 0;
    
    public void DecreaseHealth(int damage)
    {
        _currentHealth -= damage;
    }

    void OnEnable()
    {
        _currentHealth = _maxHealth;
    }
}

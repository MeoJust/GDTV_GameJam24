using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float _startHealth = 100;

    public void GetDamage(float damage)
    {
        _startHealth -= damage;
        print(gameObject.name + " health: " + _startHealth);
        if (_startHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

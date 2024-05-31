using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float _startHealth = 100;

    public Action OnDie;

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
        OnDie?.Invoke();
        Destroy(gameObject);
    }

    public float GetHealth() => _startHealth;
}

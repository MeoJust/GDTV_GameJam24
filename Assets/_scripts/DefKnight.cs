using System;
using UnityEngine;

public class DefKnight : MonoBehaviour, IDefender
{
    Fighter _fighter;
    Health _health;

    public Action IsDeadAction;

    void Start()
    {
        _fighter = GetComponent<Fighter>();
        _health = GetComponent<Health>();

        _health.OnDie += OnDie;
    }

    void OnTriggerEnter(Collider collider)
    {
        // print("enterring trigger: " + collider.name);;
        if (collider.GetComponent<IEnemy>() != null)
        {
            Attack(collider.GetComponent<Health>());
        }
    }

    public void Attack(Health health)
    {
        if (_fighter != null)
        StartCoroutine(_fighter.Attack(health));
    }

    void OnDie()
    {
        IsDeadAction?.Invoke();
        Destroy(gameObject);
    }
}

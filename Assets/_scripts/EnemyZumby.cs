using UnityEngine;

public class EnemyZumby : MonoBehaviour, IEnemy
{
    EnemyMove _mover;
    Fighter _fighter;
    Collider _defCollider;

    void Start()
    {
        _mover = GetComponent<EnemyMove>();
        _fighter = GetComponent<Fighter>();
        _mover.IsStuckAction += OnStuck;

        Move();
    }

    public void Move()
    {
        StartCoroutine(_mover.Move());
    }

    public void OnStuck()
    {
        if (_defCollider != null)
        {
            _defCollider.GetComponent<Health>().OnDie += ContinueMoving;
            Attack(_defCollider.GetComponent<Health>());
        }
    }

    public void Attack(Health health)
    {
        StartCoroutine(_fighter.Attack(health));
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<IDefender>() != null)
        {
            _defCollider = collider;
        }
    }

    void ContinueMoving()
    {
        Invoke("CanMove", 1f);
    }

    void CanMove(){
        _mover.ResumeMove();
    }
}

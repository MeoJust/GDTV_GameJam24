using UnityEngine;

public class EnemyZumby : MonoBehaviour, IEnemy
{
    EnemyMove _mover;
    Fighter _fighter;
    Health _health;

    Collider _defCollider;

    void Start()
    {
        _mover = GetComponent<EnemyMove>();
        _fighter = GetComponent<Fighter>();
        _health = GetComponent<Health>();

        _mover.IsStuckAction += OnStuck;
        _health.OnDie += OnDie;

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
            _defCollider.GetComponent<DefKnight>().IsDeadAction += ContinueMoving;
            Attack(_defCollider.GetComponent<Health>());
        }
    }

    public void Attack(Health health)
    {
        StartCoroutine(_fighter.Attack(health));
    }

    void OnTriggerEnter(Collider collider)
    {
        // print("enterring trigger: " + collider.name);
        if (collider.GetComponent<IDefender>() != null)
        {
            // print("defender found: " + collider.name);
            _defCollider = collider;
        }
    }

    void ContinueMoving()
    {
        Invoke("CanMove", 1f);
    }

    void CanMove()
    {
        if (_mover != null)
            _mover.ResumeMove();
    }

    void OnDie()
    {
        // print("zumby died");
        FindObjectOfType<LevelManager>().CountDatKills();
        Waypoint currentWaypoint = _mover.GetCurrentWaypoint();
        // print("current waypoint: " + currentWaypoint);
        if (currentWaypoint != null)
        {
            currentWaypoint.IsPlaceable = true;
        }
        CancelInvoke();
        _health.OnDie -= OnDie;
        if (_defCollider != null && _defCollider.GetComponent<DefKnight>() != null)
        {
            _defCollider.GetComponent<DefKnight>().IsDeadAction -= ContinueMoving;
        }

        Destroy(gameObject);
    }
}

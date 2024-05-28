using UnityEngine;

public class EnemyZumby : MonoBehaviour, IEnemy
{
    EnemyMove _mover;

    void Start()
    {
        _mover = GetComponent<EnemyMove>();

        _mover.IsStuckAction += OnStuck;

        Move();
    }

    public void Move()
    {
        StartCoroutine(_mover.Move());
    }

    public void OnStuck()
    {
        Attack();
    }

    public void Attack()
    {
        print(gameObject.name + " attack");
    }
}

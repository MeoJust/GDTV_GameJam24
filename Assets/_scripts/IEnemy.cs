public interface IEnemy
{
    void Move();
    void OnStuck();
    void Attack(Health health);
}
